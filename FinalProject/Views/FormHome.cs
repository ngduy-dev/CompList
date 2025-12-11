using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using FinalProject.Models;

namespace FinalProject.Views
{
    public partial class FormHome : Form, ILocalizable
    {
        static readonly string ApplicationName = "Google Sheets API .NET Quickstart";
        static readonly string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static readonly string SpreadsheetId = "1jrus-GU68-UqsFTqKARuwiyrIesNLLHhsBV0lXu11Tk";
        static readonly string SheetName = "FormResponse";

        public FormHome()
        {
            InitializeComponent();
        }

        private void FormHome_Load_1(object sender, EventArgs e)
        {
            UpdateDatabaseFromGoogleSheet();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            this.Text = LanguageManager.Translate("home_title");
            btnSendReminder.Text = LanguageManager.Translate("send_reminder");
            lblRecent.Text = LanguageManager.Translate("lblRecentResponse");

            //if (dtgRecentUpdate != null && dtgRecentUpdate.Columns.Count > 0)
            //{
            //    dtgRecentUpdate.Columns["Timestamp"].HeaderText = LanguageManager.Translate("timestamp");
            //    dtgRecentUpdate.Columns["ItemID"].HeaderText = LanguageManager.Translate("item_id");
            //    dtgRecentUpdate.Columns["Title"].HeaderText = LanguageManager.Translate("title");
            //    dtgRecentUpdate.Columns["CompletionStatus"].HeaderText = LanguageManager.Translate("completion_status");
            //    dtgRecentUpdate.Columns["EmployeeID"].HeaderText = LanguageManager.Translate("employee_id");
            //    dtgRecentUpdate.Columns["EmailAddress"].HeaderText = LanguageManager.Translate("email_address");
            //}
        }

        public void UpdateDatabaseFromGoogleSheet()
        {
            try
            {
                // Load data from Google Sheets and display in DataGridView
                var data = GetDataFromGoogleSheet();
                // Display data in DataGridView
                DisplayDataInDataGridView(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Get data from Google Sheets
        private List<FormResponse> GetDataFromGoogleSheet()
        {
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GetGoogleCredential(),
                ApplicationName = ApplicationName,
            });

            var range = $"{SheetName}!A1:E";  // Read data from columns A to E
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            List<FormResponse> formResponses = new List<FormResponse>();

            if (values != null && values.Count > 1) // Skip header (first row)
            {
                // Assuming the first row contains column headers
                foreach (var row in values.Skip(1)) // Skip the header row
                {
                    // Ensure there are enough columns in the row
                    if (row.Count >= 5)
                    {
                        formResponses.Add(new FormResponse
                        {
                            Timestamp = row[0]?.ToString(),
                            ItemID = row[1]?.ToString(),        // Changed from JobCode to ItemID
                            CompletionStatus = row[2]?.ToString(),
                            EmployeeID = row[3]?.ToString(),     // Changed from EmployeeCode to EmployeeID
                            EmailAddress = row[4]?.ToString()
                        });
                    }
                }
            }

            return formResponses;
        }

        // Get Google Sheets credentials
        public static GoogleCredential GetGoogleCredential()
        {
            string credentialPath = "quanlychecklist-440716-1c38989239d9.json";

            using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
            {
                return GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }
        }

        // Initialize DataGridView with columns
        private void InitializeDataGridViewColumns()
        {
            if (dgvRecentUpdate.Columns.Count == 0)
            {
                dgvRecentUpdate.Columns.Add("Timestamp", "Timestamp");
                dgvRecentUpdate.Columns.Add("ItemID", "Item ID");
                dgvRecentUpdate.Columns.Add("Title", "Title"); // Add Title column
                dgvRecentUpdate.Columns.Add("CompletionStatus", "Completion Status");
                dgvRecentUpdate.Columns.Add("EmployeeID", "Employee ID");
                dgvRecentUpdate.Columns.Add("EmailAddress", "Email Address");
            }
        }

        // Display data in DataGridView
        private void DisplayDataInDataGridView(List<FormResponse> data)
        {
            // Initialize columns if not already done
            InitializeDataGridViewColumns();

            // Clear existing data in DataGridView
            dgvRecentUpdate.Rows.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    foreach (var item in data)
                    {
                        // Check if ItemID and EmployeeID are valid
                        bool isItemValid = IsValidItemID(connection, item.ItemID);
                        bool isEmployeeValid = IsValidEmployeeID(connection, item.EmployeeID);

                        // Get the title for the current ItemID
                        string title = GetTitleByItemID(connection, item.ItemID);

                        // Add the item to DataGridView
                        int rowIndex = dgvRecentUpdate.Rows.Add(
                            item.Timestamp,
                            item.ItemID,
                            title, // Display title
                            item.CompletionStatus,
                            item.EmployeeID,
                            item.EmailAddress
                        );

                        // Get the row at the added index
                        DataGridViewRow row = dgvRecentUpdate.Rows[rowIndex];

                        if (isItemValid && isEmployeeValid)
                        {
                            UpdateCompletionDate(connection, item.ItemID, item.Timestamp);
                            
                        }
                        else
                        {
                            // Nếu không hợp lệ, đổi màu dòng thành đỏ
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvRecentUpdate.ClearSelection();
                dgvRecentUpdate.CurrentCell = null;
            }
        }

        private void UpdateCompletionDate(SqlConnection connection, string itemID, string timestamp)
        {
            if (string.IsNullOrEmpty(itemID) || string.IsNullOrEmpty(timestamp))
                return;

            string query = @"
            UPDATE ChecklistItem
            SET CompletionDate = @Timestamp
            WHERE ItemID = @ItemID";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Timestamp", DateTime.Parse(timestamp)); 
                cmd.Parameters.AddWithValue("@ItemID", itemID);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update CompletionDate for ItemID {itemID}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private string GetTitleByItemID(SqlConnection connection, string itemID)
        {
            if (string.IsNullOrEmpty(itemID))
                return "N/A";

            string query = "SELECT TaskDescription FROM ChecklistItem WHERE ItemID = @ItemID";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ItemID", itemID);
                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "Error response";
            }
        }



        // Check if ItemID exists in the database
        private bool IsValidItemID(SqlConnection connection, string itemID)
        {
            string query = "SELECT COUNT(1) FROM ChecklistItem WHERE ItemID = @ItemID"; // Modified to ItemID
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ItemID", itemID);
                return (int)command.ExecuteScalar() > 0;
            }
        }

        // Check if EmployeeID exists in the database
        private bool IsValidEmployeeID(SqlConnection connection, string employeeID)
        {
            string query = "SELECT COUNT(1) FROM Employee WHERE EmployeeID = @EmployeeID"; // Modified to EmployeeID
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeID", employeeID);
                return (int)command.ExecuteScalar() > 0;
            }
        }

        private void btnSendReminder_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsDirector)
            {
                btnSendReminder.Visible =  false;
            }
            try
            {
                // Get the currently selected row
                DataGridViewRow row = dgvRecentUpdate.CurrentRow;

                // Ensure a row is selected
                if (row != null && !row.IsNewRow)
                {
                    // Check if the row has a red background
                    if (row.DefaultCellStyle.BackColor == System.Drawing.Color.Red)
                    {
                        // Get values from the current row
                        string itemId = row.Cells["ItemID"].Value?.ToString();
                        string employeeId = row.Cells["EmployeeID"].Value?.ToString();
                        string emailAddress = row.Cells["EmailAddress"].Value?.ToString();

                        // Check if the ItemID and EmployeeID are valid using the validation functions
                        using (SqlConnection connection = new SqlConnection(Program.connectionString))
                        {
                            connection.Open();

                            bool isValidJobCode = IsValidItemID(connection, itemId);
                            bool isValidEmployeeCode = IsValidEmployeeID(connection, employeeId);

                            if (!isValidJobCode || !isValidEmployeeCode)
                            {
                                SendReminderEmail(emailAddress, itemId, employeeId);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("This response is valid.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid row.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please try later!");
            }
        }


        private void SendReminderEmail(string toEmailAddress, string itemId, string employeeId)
        {
            // Cấu hình SMTP
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("cnpmquatrinh2@gmail.com", "eqyr zjud dbgn hbik"),
                EnableSsl = true,
            };

            // Nội dung email
            var mailMessage = new MailMessage
            {
                From = new MailAddress("cnpmquatrinh2@gmail.com"), // Email người gửi
                Subject = "Nhắc nhở: Phản hồi công việc không hợp lệ",
                Body = $"Xin chào,\n\nChúng tôi phát hiện có một phản hồi không hợp lệ với thông tin sau:\n\n" +
                       $"Mã công việc: {itemId}\n" +
                       $"Mã nhân viên: {employeeId}\n\n" +
                       "Vui lòng kiểm tra và sửa lại thông tin.\n\n" +
                       "Trân trọng,\n" +
                       "Phòng quản lý công việc",
                IsBodyHtml = false, // Nội dung dạng văn bản
            };


            mailMessage.To.Add(toEmailAddress); // Gửi đến email nhận

            try
            {
                smtpClient.Send(mailMessage);
                MessageBox.Show("Email sent successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
            }
        }
    }

    // Class to describe data from sheet "FormResponse"
    public class FormResponse
    {
        public string Timestamp { get; set; }
        public string ItemID { get; set; }             
        public string CompletionStatus { get; set; }
        public string EmployeeID { get; set; }          
        public string EmailAddress { get; set; }
    }
}
