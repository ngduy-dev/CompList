using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using FinalProject.Models;

namespace FinalProject.Views
{
    public partial class FormUpdateChecklistItem : Form, ILocalizable
    {
        public string itemID { get; set; }
        public string checklistID { get; set; }
        string connectionString = Program.connectionString;

        public FormUpdateChecklistItem(string itemID, string checklistID)
        {
            InitializeComponent();
            this.itemID = itemID; // Gán itemID từ tham số
            this.checklistID = checklistID; // Gán checklistID từ tham số
            lblChecklistID.Text = $"Update task for Item ID: {this.itemID}";
            LoadEmployees();
            LoadChecklistItemData(); // Gọi phương thức để tải dữ liệu của checklist item
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            lblChecklistID.Text = LanguageManager.Translate("updatefor");
            txtTaskDescription.Text = LanguageManager.Translate("description");
            lblIsComplete.Text = LanguageManager.Translate("status");
            lblAssign.Text = LanguageManager.Translate("assignee");
            lblDueDate.Text = LanguageManager.Translate("due_date");
            btnSave.Text = LanguageManager.Translate("save");
        }

        private void LoadEmployees()
        {
            // Đặt chuỗi kết nối của bạn

            string departmentID = "";

            // Lấy DepartmentID từ ChecklistID
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DepartmentID FROM Checklist WHERE ChecklistID = @ChecklistID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ChecklistID", this.checklistID);
                    departmentID = command.ExecuteScalar()?.ToString();
                }
            }

            // Tải danh sách nhân viên dựa trên DepartmentID
            if (!string.IsNullOrEmpty(departmentID))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT EmployeeID, Name FROM Employee WHERE DepartmentID = @DepartmentID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DepartmentID", departmentID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Thêm nhân viên vào comboBoxEmployeeID
                                cmbEmployeeID.Items.Add(new
                                {
                                    Value = reader["EmployeeID"],
                                    Text = reader["Name"]
                                });
                            }
                        }
                    }
                }
            }

            // Thiết lập giá trị hiển thị cho comboBox
            cmbEmployeeID.DisplayMember = "Text";
            cmbEmployeeID.ValueMember = "Value";
        }

        private void LoadChecklistItemData()
        {
            // Kết nối đến cơ sở dữ liệu và lấy thông tin của checklist item
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TaskDescription, IsCompleted, DueDate, EmployeeID FROM ChecklistItem WHERE ItemID = @ItemID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemID", this.itemID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Gán dữ liệu vào các trường thông tin
                            txtTaskDescription.Text = reader["TaskDescription"].ToString();
                            cmbIsComplete.SelectedItem = Convert.ToBoolean(reader["IsCompleted"]) ? "Complete" : "Not Complete";
                            dtpDueDate.Value = reader["DueDate"] != DBNull.Value
                            ? Convert.ToDateTime(reader["DueDate"])
                            : DateTime.Now; // Giá trị mặc định nếu NULL


                            // Tìm kiếm và chọn nhân viên trong comboBox
                            string employeeID = reader["EmployeeID"].ToString();
                            foreach (var item in cmbEmployeeID.Items)
                            {
                                if ((item as dynamic)?.Value.ToString() == employeeID)
                                {
                                    cmbEmployeeID.SelectedValue = item;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Checklist item not found with ID: " + this.itemID);
                        }
                    }
                }
            }
        }

        private async void buttonSaveChecklistItem_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các trường nhập liệu
            string taskDescription = txtTaskDescription.Text;
            bool isCompleted = cmbIsComplete.SelectedItem?.ToString() == "Complete";
            DateTime dueDate = dtpDueDate.Value; // Ngày hết hạn
            string employeeID = (cmbEmployeeID.SelectedItem as dynamic)?.Value; // ID nhân viên

            // Kiểm tra xem mô tả công việc có trống không
            if (string.IsNullOrWhiteSpace(taskDescription))
            {
                MessageBox.Show("Please enter the job description.");
                return;
            }

            // Kiểm tra xem ngày hết hạn có hợp lệ không
            if (dueDate < DateTime.Today)
            {
                MessageBox.Show("The due date cannot be earlier than today.", "Invalid Due Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy email của nhân viên cũ và nhân viên mới
            string oldEmployeeEmail = string.Empty;
            string newEmployeeEmail = string.Empty;
            string oldEmployeeName = string.Empty;
            string newEmployeeName = string.Empty;

            // Lấy thông tin email của nhân viên cũ và nhân viên mới từ cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT Employee.Email, Employee.Name
            FROM Employee
            WHERE Employee.EmployeeID = @EmployeeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                newEmployeeEmail = reader["Email"].ToString();
                                newEmployeeName = reader["Name"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while retrieving new employee information: {ex.Message}");
                        return;
                    }
                }

                // Lấy thông tin email của nhân viên cũ
                string oldEmployeeQuery = @"
            SELECT Employee.Email, Employee.Name
            FROM Employee
            JOIN ChecklistItem ON ChecklistItem.EmployeeID = Employee.EmployeeID
            WHERE ChecklistItem.ItemID = @ItemID";

                using (SqlCommand command = new SqlCommand(oldEmployeeQuery, connection))
                {
                    command.Parameters.AddWithValue("@ItemID", this.itemID);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                oldEmployeeEmail = reader["Email"].ToString();
                                oldEmployeeName = reader["Name"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while retrieving old employee information: {ex.Message}");
                        return;
                    }
                }
            }

            // Cập nhật checklist item vào cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE ChecklistItem SET TaskDescription = @TaskDescription, IsCompleted = @IsCompleted, DueDate = @DueDate, EmployeeID = @EmployeeID WHERE ItemID = @ItemID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaskDescription", taskDescription);
                    command.Parameters.AddWithValue("@IsCompleted", isCompleted);
                    command.Parameters.AddWithValue("@DueDate", dueDate);
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.Parameters.AddWithValue("@ItemID", this.itemID); // Sử dụng ItemID hiện tại

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery(); // Thực hiện truy vấn
                        if (rowsAffected > 0)
                        {
                            // Gửi email thông báo cho nhân viên cũ và nhân viên mới
                            await SendEmailNotification(this.itemID, taskDescription, newEmployeeName, dueDate.ToString("dd/MM/yyyy"), isCompleted, newEmployeeEmail, oldEmployeeEmail, oldEmployeeName);
                        }
                        else
                        {
                            MessageBox.Show("No changes were made.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
            this.Close(); // Đóng form sau khi cập nhật
        }


        private async Task SendEmailNotification(string itemID, string taskDescription, string newEmployeeName, string dueDate, bool isCompleted, string newEmployeeEmail, string oldEmployeeEmail, string oldEmployeeName)
        {
            // Cấu hình người gửi email
            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                Credentials = new System.Net.NetworkCredential("cnpmquatrinh2@gmail.com", "eqyr zjud dbgn hbik"),
                DeliveryMethod = SmtpDeliveryMethod.Network
            });

            Email.DefaultSender = sender;

            // Cấu trúc nội dung email
            string emailBody = $@"
Xin chào, 
COMPLIST xin thông báo về công việc {itemID}. 
Chi tiết như sau: 
• Mô tả công việc: {taskDescription} 
• Ngày giao việc: {DateTime.Now.ToString("dd/MM/yyyy")} 
• Người giao việc: {UserSession.Username}
• Nhân viên cũ phụ trách: {oldEmployeeName} 
• Nhân viên mới phụ trách: {newEmployeeName} 
• Thời hạn hoàn thành: {dueDate} 
• Tình trạng: {(isCompleted ? "Hoàn thành" : "Chưa hoàn thành")} 
Đây là email/tin nhắn tự động được gửi từ hệ thống, bạn không cần phải hồi đáp cho email/tin nhắn này.";

            try
            {
                // Gửi email cho nhân viên mới
                var newEmployeeEmailResult = await Email
                    .From("cnpmquatrinh2@gmail.com")
                    .To(newEmployeeEmail)
                    .Subject($"{itemID} Task Notification - New Assignment")
                    .Body(emailBody)
                    .SendAsync();

                if (!newEmployeeEmailResult.Successful)
                {
                    MessageBox.Show("Failed to send the email to the new employee. Please check the information.");
                }

                // Gửi email cho nhân viên cũ
                var oldEmployeeEmailResult = await Email
                    .From("cnpmquatrinh2@gmail.com")
                    .To(oldEmployeeEmail)
                    .Subject($"{itemID} Task Notification - Old Assignment")
                    .Body(emailBody)
                    .SendAsync();

                if (!oldEmployeeEmailResult.Successful)
                {
                    MessageBox.Show("Failed to send the email to the old employee. Please check the information.");
                }

                MessageBox.Show("Checklist item has been successfully updated and emails have been sent.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while sending the email: {ex.Message}");
            }
        }



    }
}
