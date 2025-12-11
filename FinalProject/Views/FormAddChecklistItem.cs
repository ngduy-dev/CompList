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
using FluentEmail.Smtp;
using System.Net.Mail;
using FluentEmail.Core;
using System.Windows.Input;
using FinalProject.Models;

namespace FinalProject.Views
{
    public partial class formAddChecklistItem : Form, ILocalizable
    {
        public string checklistID { get; set; }
        //string connectionString = "Data Source=MSIBRAVO15\\QUOCDUY;Initial Catalog=CHECKLIST;Integrated Security=True";
        string connectionString = Program.connectionString;

        public formAddChecklistItem(string checklistId)
        {
            InitializeComponent();
            this.checklistID = checklistId; // Gán checklistID từ tham số
            lblChecklistID.Text = $"Add task for Checklist ID: {this.checklistID}";
            LoadEmployees();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            txtTaskDescription.Text = LanguageManager.Translate("description");
            lblAssign.Text = LanguageManager.Translate("assignee");
            lblComplete.Text = LanguageManager.Translate("status");
            lblDueDate.Text = LanguageManager.Translate("due_date");
            btnAddChecklistItem.Text = LanguageManager.Translate("btn_add_cl");
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


        private string getEmployeeEmail(string employeeID)
        {
            string email = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Email FROM Employee WHERE EmployeeID = @EmployeeID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    email = command.ExecuteScalar()?.ToString();
                }
            }
            return email;
        }

        private async Task SendEmailNotification(string itemID, string taskDescription, string employeeName, string dueDate, bool isCompleted, string employeeEmail)
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

            // Nội dung Body email theo format yêu cầu
            string emailBody = $@"
Xin chào, 
COMPLIST thông báo Giao việc {itemID}. 
Thông tin cụ thể như sau: 
• Mô tả yêu cầu: {taskDescription} 
• Ngày giao việc: {DateTime.Now.ToString("dd/MM/yyyy")} 
• Người giao việc: {UserSession.Username}
• Nhân viên phụ trách: {employeeName} 
• Thời hạn hoàn thành: {dueDate} 
• Tình trạng xử lý: {(isCompleted ? "Hoàn thành" : "Chưa hoàn thành")} 
Đây là Email/Tin nhắn được gửi tự động từ Hệ thống, Bạn không cần phải hồi đáp cho Email/Tin nhắn này.";

            try
            {
                var email = await Email
                    .From("cnpmquatrinh2@gmail.com")
                    .To(employeeEmail)
                    .Subject($"{itemID} Thông báo Giao việc")
                    .Body(emailBody)
                    .SendAsync();

                if (email.Successful)
                {
                    MessageBox.Show("Checklist item has been successfully added.\nAnd an email has been sent to the employee!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Email sending failed. Please check the information again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
            }
        }

        private string GenerateItemID(string checklistID)
        {
            string newItemID = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Step 1: Get the DepartmentID from the Checklist table
                    string departmentID = string.Empty;
                    string getDepartmentQuery = "SELECT DepartmentID FROM Checklist WHERE ChecklistID = @ChecklistID";

                    using (SqlCommand getDeptCommand = new SqlCommand(getDepartmentQuery, connection))
                    {
                        getDeptCommand.Parameters.AddWithValue("@ChecklistID", checklistID);
                        object result = getDeptCommand.ExecuteScalar();

                        if (result != null)
                        {
                            departmentID = result.ToString().Trim();
                        }
                        else
                        {
                            throw new Exception("ChecklistID not found or has no associated DepartmentID.");
                        }
                    }

                    // Step 2: Generate the new ItemID
                    string getMaxItemQuery = @"
                SELECT ISNULL(MAX(CAST(SUBSTRING(ItemID, LEN(@DepartmentID) + 6, LEN(ItemID) - LEN(@DepartmentID) - 5) AS INT)), 0)
                FROM ChecklistItem
                WHERE ChecklistID = @ChecklistID AND ItemID LIKE @DepartmentID + '-ITEM%'";

                    using (SqlCommand getMaxItemCommand = new SqlCommand(getMaxItemQuery, connection))
                    {
                        getMaxItemCommand.Parameters.AddWithValue("@ChecklistID", checklistID);
                        getMaxItemCommand.Parameters.AddWithValue("@DepartmentID", departmentID);

                        int newNumber = (int)getMaxItemCommand.ExecuteScalar() + 1;

                        // Format the new ItemID
                        newItemID = $"{departmentID}-ITEM{newNumber:D4}";
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error or show a message)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return newItemID;
        }

        private async void btnAddChecklistItem_Click(object sender, EventArgs e)
        {
            // Vô hiệu hóa nút để ngăn nhấn liên tục
            btnAddChecklistItem.Enabled = false;

            // Check if a user has selected an employee
            if (cmbEmployeeID.SelectedItem == null)
            {
                MessageBox.Show("Please select an employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAddChecklistItem.Enabled = true;
                return;
            }

            // Retrieve information from input fields
            string taskDescription = txtTaskDescription.Text;
            bool isCompleted = cmbIsComplete.SelectedItem?.ToString() == "Complete";
            DateTime dueDate = dtpDueDate.Value; // Due date
            string employeeID = (cmbEmployeeID.SelectedItem as dynamic)?.Value; // Employee ID
            string employeeName = (cmbEmployeeID.SelectedItem as dynamic)?.Text; // Employee name
            DateTime createDate = DateTime.Now;

            // Check if task description is empty
            if (string.IsNullOrWhiteSpace(taskDescription))
            {
                MessageBox.Show("Please enter the task description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAddChecklistItem.Enabled = true;
                return;
            }

            // Check employee status (IsActive)
            bool isEmployeeActive = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkEmployeeQuery = "SELECT IsActive FROM Employee WHERE EmployeeID = @EmployeeID";
                using (SqlCommand command = new SqlCommand(checkEmployeeQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    object result = command.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnAddChecklistItem.Enabled = true;
                        return;
                    }
                    isEmployeeActive = Convert.ToBoolean(result);
                }
            }

            if (!isEmployeeActive)
            {
                MessageBox.Show("The selected employee is inactive. Please choose an active employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAddChecklistItem.Enabled = true;
                return;
            }

            // Retrieve CreatedDate and DueDate of the Checklist
            DateTime checklistCreatedDate;
            DateTime checklistDueDate;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT CreatedDate, DueDate FROM Checklist WHERE ChecklistID = @ChecklistID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ChecklistID", this.checklistID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            checklistCreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                            checklistDueDate = Convert.ToDateTime(reader["DueDate"]);
                        }
                        else
                        {
                            MessageBox.Show("Checklist information not found. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnAddChecklistItem.Enabled = true;
                            return;
                        }
                    }
                }
            }

            if (dueDate < DateTime.Today)
            {
                MessageBox.Show("Due date cannot be earlier than today.", "Invalid Due Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAddChecklistItem.Enabled = true;
                return;
            }

            // Generate a new ID for the checklist item
            string newItemID = GenerateItemID(this.checklistID);

            try
            {
                // Add the checklist item to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DateTime? completionDate;
                    if (isCompleted)
                    {
                        completionDate = DateTime.Today;
                    }
                    else
                    {
                        completionDate = null;
                    }

                    connection.Open();
                    string query = "INSERT INTO ChecklistItem (ItemID, ChecklistID, TaskDescription, IsCompleted, CreateDate, DueDate, EmployeeID, CompletionDate) " +
                                   "VALUES (@ItemID, @ChecklistID, @TaskDescription, @IsCompleted, @CreateDate, @DueDate, @EmployeeID, @CompletionDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemID", newItemID); // Use the new ID
                        command.Parameters.AddWithValue("@ChecklistID", this.checklistID); // Use saved ChecklistID
                        command.Parameters.AddWithValue("@TaskDescription", taskDescription);
                        command.Parameters.AddWithValue("@IsCompleted", isCompleted);
                        command.Parameters.AddWithValue("@CreateDate", createDate);
                        command.Parameters.AddWithValue("@DueDate", dueDate); // Use dueDate value
                        command.Parameters.AddWithValue("@EmployeeID", employeeID); 
                        if (completionDate.HasValue)
                        {
                            command.Parameters.Add("@CompletionDate", SqlDbType.DateTime).Value = completionDate.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@CompletionDate", SqlDbType.DateTime).Value = DBNull.Value;
                        }


                        command.ExecuteNonQuery(); // Execute the query

                        // Send email notification after successfully adding the checklist item
                        await SendEmailNotification(newItemID, taskDescription, employeeName, dueDate.ToString("dd/MM/yyyy"), isCompleted, getEmployeeEmail(employeeID));
                        this.Close();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL errors
                MessageBox.Show($"SQL Error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle other errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnAddChecklistItem.Enabled = true;
        }
    }
}
