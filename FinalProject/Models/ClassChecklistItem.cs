using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace FinalProject.Models
{
    public class ClassChecklistItem
    {
        public string ItemID { get; set; }
        public string ChecklistID { get; set; }
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
        public string EmployeeID { get; set; }

        // Hàm cập nhật thông tin task (UPDATE vào cơ sở dữ liệu)
        public bool UpdateTask(SqlConnection conn)
        {
            try
            {
                string query = @"
                    UPDATE [ChecklistItem]
                    SET [TaskDescription] = @TaskDescription, [IsCompleted] = @IsCompleted, [DueDate] = @DueDate, [EmployeeID] = @EmployeeID
                    WHERE [ItemID] = @ItemID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ItemID", ItemID);
                cmd.Parameters.AddWithValue("@TaskDescription", TaskDescription ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IsCompleted", IsCompleted);
                cmd.Parameters.AddWithValue("@DueDate", DueDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID ?? (object)DBNull.Value);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating task: " + ex.Message);
                return false;
            }
        }

        // Hàm thông báo cho nhân viên về công việc (notify) qua email
        public bool NotifyEmployeeOnTask(SqlConnection conn)
        {
            try
            {
                // Lấy thông tin email của nhân viên từ cơ sở dữ liệu
                string employeeEmail = GetEmployeeEmail(conn);
                if (string.IsNullOrEmpty(employeeEmail))
                {
                    Console.WriteLine("Employee email not found.");
                    return false;
                }

                // Tạo nội dung email
                string subject = $"Task Notification for Checklist: {ChecklistID}";
                string body = $"Dear Employee,\n\nYou have a new task assigned:\n\n" +
                              $"Task Description: {TaskDescription}\n" +
                              $"Due Date: {DueDate?.ToString("yyyy-MM-dd")}\n\n" +
                              "Please complete the task on time.\n\nBest Regards,\nYour System";

                // Gửi email
                return SendEmail(employeeEmail, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error notifying employee: " + ex.Message);
                return false;
            }
        }

        // Hàm lấy email của nhân viên từ cơ sở dữ liệu
        private string GetEmployeeEmail(SqlConnection conn)
        {
            try
            {
                string query = "SELECT [Email] FROM [Employee] WHERE [EmployeeID] = @EmployeeID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                return result as string;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving employee email: " + ex.Message);
                return null;
            }
        }

        // Hàm gửi email thông báo
        private bool SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                // Thông tin cấu hình email
                var smtpClient = new SmtpClient("smtp.your-email-provider.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("your-email@example.com", "your-email-password"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("your-email@example.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false,
                };

                mailMessage.To.Add(toEmail);

                // Gửi email
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
                return false;
            }
        }
    }
}
