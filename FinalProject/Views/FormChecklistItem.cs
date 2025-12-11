using FinalProject.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Views
{
    public partial class FormChecklistItem : Form, ILocalizable
    {
        public string checklistID { get; set; }
        static readonly string ApplicationName = "Google Sheets API .NET Quickstart";
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string SheetName = "Data";
        static readonly string SpreadsheetId = "1jrus-GU68-UqsFTqKARuwiyrIesNLLHhsBV0lXu11Tk";

        public FormChecklistItem(string checklistId)
        {
            InitializeComponent();
            this.checklistID = checklistId;

            // Gọi các hàm để tải thông tin checklist khi form được tạo
            LoadChecklistInfo();
            LoadChecklistItem();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            lblStatuss.Text = LanguageManager.Translate("status");
            lblDescription.Text = LanguageManager.Translate("description");
            lblDepartmentChecklist.Text = LanguageManager.Translate("departments");
            lblCreate.Text = LanguageManager.Translate("createby");
            lblCreateDate.Text = LanguageManager.Translate("create_date");
            lblDue.Text = LanguageManager.Translate("due_date");
            lblTasks.Text = LanguageManager.Translate("Task");
            btnReload.Text = LanguageManager.Translate("reload");
            btnDelete.Text = LanguageManager.Translate("delete");
            btnUpdate.Text = LanguageManager.Translate("update");
            btnAdd.Text = LanguageManager.Translate("addnewtask");
            btnReceiveResponse.Text = LanguageManager.Translate("recieveresponse");
            btnExport.Text = LanguageManager.Translate("exportp");
            if (dgvChecklistItem.Columns.Count > 0)
            {
                dgvChecklistItem.Columns["ItemTask"].HeaderText = LanguageManager.Translate("ItemTask");
                dgvChecklistItem.Columns["EmployeeInfo"].HeaderText = LanguageManager.Translate("employee_information");
                dgvChecklistItem.Columns["CreateDate"].HeaderText = LanguageManager.Translate("create_date");
                dgvChecklistItem.Columns["CompletionDate"].HeaderText = LanguageManager.Translate("complete_date");
                dgvChecklistItem.Columns["DueDate"].HeaderText = LanguageManager.Translate("due_date"); 
                dgvChecklistItem.Columns["IsCompleted"].HeaderText = LanguageManager.Translate("status");
            }
        }
             

        public void LoadChecklistInfo()
        {
            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                // Truy vấn để lấy thông tin của checklist theo ID và tên phòng ban
                string query = @"
                SELECT c.ChecklistID, c.Title, c.Status, c.Description, c.DepartmentID, d.DepartmentName, TRIM(c.DepartmentID) + ' - ' + d.DepartmentName AS DepartmentID_Name, c.CreatedDate, c.DueDate, u.FullName AS CreatedBy
                FROM Checklist c
                LEFT JOIN Department d ON c.DepartmentID = d.DepartmentID
                LEFT JOIN [User] u ON c.CreatedByID = u.UserID
                WHERE c.ChecklistID = @ChecklistID";
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu lệnh SQL
                        command.Parameters.AddWithValue("@ChecklistID", this.checklistID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Lấy thông tin từ reader và hiển thị lên giao diện
                                lblTitle.Text = reader["Title"].ToString() + "_" + reader["ChecklistID"].ToString(); // Sử dụng ChecklistID từ cơ sở dữ liệu
                                lblStatus.Text = reader["Status"].ToString();
                                txtDescript.Text = reader["Description"].ToString();
                                lblDepartment.Text = reader["DepartmentID_Name"].ToString(); // Lấy tên phòng ban
                                lblCreatedDate.Text = Convert.ToDateTime(reader["CreatedDate"]).ToShortDateString();
                                lblDueDate.Text = Convert.ToDateTime(reader["DueDate"]).ToShortDateString();

                                // Lấy thông tin người tạo và gán vào lblCreateBy
                                lblCreateBy.Text = reader["CreatedBy"].ToString(); // Hiển thị tên người tạo từ bảng User
                            }
                            else
                            {
                                MessageBox.Show("Checklist with ID: " + this.checklistID + " not found.");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show($"Error to connect database");
                }
            }
        }
        public void LoadChecklistItem()
        {
            // Check if ChecklistID is assigned
            if (string.IsNullOrEmpty(this.checklistID))
            {
                MessageBox.Show("Checklist ID is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Connect to the database
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    // Query to get checklist items, employee names and CreateDate
                    string query = @"
                        SELECT 
                            ci.ItemID, 
                            ci.TaskDescription, 
                            CONCAT(TRIM(ci.ItemID), ' - ', ci.TaskDescription) AS ItemTask,
                            CONCAT(TRIM(ci.EmployeeID), ' - ', e.Name) AS EmployeeInfo,
                            ci.CreateDate,
                            ci.DueDate, 
                            ci.CompletionDate,
                            ci.EmployeeID, 
                            ci.IsCompleted, 
                            e.Name AS EmployeeName
                        FROM ChecklistItem ci
                        LEFT JOIN Employee e ON ci.EmployeeID = e.EmployeeID
                        WHERE ci.ChecklistID = @ChecklistID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ChecklistID", this.checklistID);

                        // Create a DataTable to hold the data
                        DataTable checklistItemsTable = new DataTable();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(checklistItemsTable);
                        }

                        // Assign data to DataGridView
                        dgvChecklistItem.DataSource = checklistItemsTable;

                        // Rename columns in the DataGridView
                        dgvChecklistItem.Columns["ItemTask"].HeaderText = "Item - Task Description";
                        dgvChecklistItem.Columns["EmployeeInfo"].HeaderText = "Employee - Name";
                        dgvChecklistItem.Columns["CreateDate"].HeaderText = "Create Date";
                        dgvChecklistItem.Columns["CompletionDate"].HeaderText = "Completion Date";
                        dgvChecklistItem.Columns["DueDate"].HeaderText = "Due Date";
                        dgvChecklistItem.Columns["IsCompleted"].HeaderText = "Completed";

                        // Make sure all the columns are visible
                        dgvChecklistItem.Columns["ItemID"].Visible = false;
                        dgvChecklistItem.Columns["EmployeeID"].Visible = false;
                        dgvChecklistItem.Columns["TaskDescription"].Visible = false;
                        dgvChecklistItem.Columns["EmployeeName"].Visible = false;
                    }
                }
                
            } 
            catch
            {
                MessageBox.Show($"Error to connect database");
            }
        }
        public void LoadDataToDataGridView()
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM ChecklistItem";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvChecklistItem.DataSource = dataTable;
                }
            }
        }
        public static GoogleCredential GetGoogleCredential()
        {
            string credentialPath = "quanlychecklist-440716-1c38989239d9.json";

            using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
            {
                return GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }
        }


        public DataTable GetDataFromGoogleSheet()
        {
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GetGoogleCredential(),
                ApplicationName = ApplicationName,
            });

            var range = $"{SheetName}!A1:H";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            DataTable dt = new DataTable();
            dt.Columns.Add("ItemID".Trim());
            dt.Columns.Add("ChecklistID");
            dt.Columns.Add("TaskDescription");
            dt.Columns.Add("IsCompleted");
            dt.Columns.Add("CreateDate");
            dt.Columns.Add("DueDate");
            dt.Columns.Add("EmployeeID");
            dt.Columns.Add("LastestResponse");

            if (values != null && values.Count > 1)
            {
                foreach (var row in values.Skip(1))
                {
                    dt.Rows.Add(row.ToArray());
                }
            }

            return dt;
        }

        public void UploadDataToSqlServer(DataTable googleSheetData)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                foreach (DataRow row in googleSheetData.Rows)
                {
                    try
                    {
                        string itemID = row["ItemID"]?.ToString().Trim();
                        string checklistID = row["ChecklistID"].ToString();

                        // Kiểm tra nếu itemID và checklistID đã tồn tại trong cơ sở dữ liệu
                        string checkQuery = "SELECT COUNT(1) FROM ChecklistItem WHERE ItemID = @ItemID AND ChecklistID = @ChecklistID";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@ItemID", itemID);
                            checkCommand.Parameters.AddWithValue("@ChecklistID", checklistID);

                            int exists = Convert.ToInt32(checkCommand.ExecuteScalar());
                            if (exists == 0)
                            {
                                // Thêm mới dòng nếu chưa tồn tại
                                string insertQuery = @"
                                    INSERT INTO ChecklistItem (ItemID, ChecklistID, TaskDescription, IsCompleted, CreateDate, DueDate, EmployeeID)
                                    VALUES (@ItemID, @ChecklistID, @TaskDescription, @IsCompleted, @CreateDate,  @DueDate, @EmployeeID)";

                             

                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@ItemID", itemID);
                                    insertCommand.Parameters.AddWithValue("@ChecklistID", checklistID);
                                    insertCommand.Parameters.AddWithValue("@TaskDescription", row["TaskDescription"] ?? DBNull.Value);
                                    insertCommand.Parameters.AddWithValue("@IsCompleted", row["IsCompleted"] is string isCompletedValue &&
                                        (isCompletedValue == "1" || isCompletedValue.ToLower() == "true" || isCompletedValue.ToLower() == "yes"));
                                    insertCommand.Parameters.AddWithValue("@CreateDate", row["CreateDate"] is string createDateValue &&
                                        DateTime.TryParse(createDateValue, out DateTime createDate) ? (object)createDate : DBNull.Value);
                                    insertCommand.Parameters.AddWithValue("@DueDate", row["DueDate"] is string dueDateValue &&
                                        DateTime.TryParse(dueDateValue, out DateTime dueDate) ? (object)dueDate : DBNull.Value);
                                    insertCommand.Parameters.AddWithValue("@EmployeeID", row["EmployeeID"] ?? DBNull.Value);

                                    insertCommand.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // Cập nhật nếu đã tồn tại
                                string updateQuery = @"
                                UPDATE ChecklistItem
                                SET TaskDescription = @TaskDescription,
                                    IsCompleted = @IsCompleted,
                                    CreateDate = @CreateDate,
                                    DueDate = @DueDate,
                                    EmployeeID = @EmployeeID
                                WHERE ItemID = @ItemID AND ChecklistID = @ChecklistID";

                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    // Lấy giá trị từ DataTable `dt`
                                    updateCommand.Parameters.AddWithValue("@TaskDescription", row["TaskDescription"] ?? DBNull.Value);

                                    // Sử dụng giá trị từ LastestResponse để cập nhật IsCompleted
                                    updateCommand.Parameters.AddWithValue("@IsCompleted", row["LastestResponse"] is string lastestResponseValue &&
                                        (lastestResponseValue == "1" || lastestResponseValue.ToLower() == "true" || lastestResponseValue.ToLower() == "yes") ? 1 : 0);

                                    updateCommand.Parameters.AddWithValue("@CreateDate", row["CreateDate"] is string createDateValue &&
                                        DateTime.TryParse(createDateValue, out DateTime createDate) ? (object)createDate : DBNull.Value);

                                    // Chuyển đổi DueDate từ string nếu có giá trị hợp lệ
                                    updateCommand.Parameters.AddWithValue("@DueDate", row["DueDate"] is string dueDateValue &&
                                        DateTime.TryParse(dueDateValue, out DateTime dueDate) ? (object)dueDate : DBNull.Value);

                                    updateCommand.Parameters.AddWithValue("@EmployeeID", row["EmployeeID"] ?? DBNull.Value);
                                    updateCommand.Parameters.AddWithValue("@ItemID", itemID.Trim());
                                    updateCommand.Parameters.AddWithValue("@ChecklistID", checklistID);

                                    updateCommand.ExecuteNonQuery();
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding or updating ItemID '{row["ItemID"]}': {ex.Message}");
                    }
                }
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            formAddChecklistItem addChecklistItem = new formAddChecklistItem(this.checklistID);
            addChecklistItem.ShowDialog();
            // Sau khi thêm vào SQL Server, lấy dòng vừa thêm để đồng bộ lên Google Sheets
            DataRow newRow = GetLatestChecklistItem(this.checklistID);
            if (newRow != null)
            {
                AppendRowToGoogleSheet(newRow);
            }
            else
            {
                MessageBox.Show("Unable to find the recently added row.");
            }
            UpdateChecklistDueDate();
            LoadChecklistItem();
        }

        public void UploadSQLServerToSheet()
        {
            // Kết nối đến SQL Server
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                // Truy vấn dữ liệu từ bảng ChecklistItem
                string selectQuery = "SELECT ItemID, ChecklistID, TaskDescription, IsCompleted, CreateDate, DueDate, EmployeeID FROM ChecklistItem WHERE ChecklistID = @ChecklistID";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    command.Parameters.AddWithValue("@ChecklistID", this.checklistID);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Kiểm tra nếu không có dữ liệu trong SQL Server
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("There is no data to upload to Google Sheets.");
                        return;
                    }

                    // Mở kết nối đến Google Sheets
                    var service = new SheetsService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = GetGoogleCredential(),
                        ApplicationName = ApplicationName,
                    });

                    // Lấy dữ liệu hiện tại từ Google Sheets
                    var range = $"{SheetName}!A1:G"; // Phạm vi toàn bộ dữ liệu
                    var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
                    var response = request.Execute();
                    var values = response.Values;

                    // Duyệt qua từng dòng trong DataTable và cập nhật vào Google Sheets
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Tìm dòng cần ghi đè trong Google Sheets
                        int rowIndexToUpdate = -1;
                        for (int i = 1; i < values.Count; i++) // Bắt đầu từ i = 1 vì hàng đầu tiên là tiêu đề
                        {
                            if (values[i][0].ToString().Trim() == row["ItemID"].ToString().Trim()) // So sánh ItemID
                            {
                                rowIndexToUpdate = i;
                                break;
                            }
                        }

                        // Nếu không tìm thấy dòng cần cập nhật, thông báo lỗi
                        if (rowIndexToUpdate == -1)
                        {
                            AppendRowToGoogleSheet(row); // Thêm dòng mới nếu không tìm thấy
                            continue; // Tiếp tục với dòng tiếp theo
                        }

                        // Chuẩn bị dữ liệu cần cập nhật
                        var updatedValues = new List<object>
                            {
                                row["ItemID"].ToString().Trim(),
                                row["ChecklistID"].ToString().Trim(),
                                row["TaskDescription"].ToString(),
                                (row["IsCompleted"] is bool completed && completed) ? "1" : "0", // Chuyển thành 1 hoặc 0
                                row["CreateDate"] != DBNull.Value ? row["CreateDate"].ToString() : values[rowIndexToUpdate][4].ToString(), // Giữ giá trị cũ nếu CreateDate trống
                                row["DueDate"] != DBNull.Value ? row["DueDate"].ToString() : values[rowIndexToUpdate][5].ToString(),       // Giữ giá trị cũ nếu DueDate trống
                                row["EmployeeID"].ToString().Trim()
                            };

                        // Xác định phạm vi để ghi đè
                        var updateRange = $"{SheetName}!A{rowIndexToUpdate + 1}:G{rowIndexToUpdate + 1}"; // Cập nhật dòng cần thiết

                        var valueRange = new Google.Apis.Sheets.v4.Data.ValueRange
                        {
                            Values = new List<IList<object>> { updatedValues }
                        };

                        // Gửi yêu cầu cập nhật
                        var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, updateRange);
                        updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                        var updateResponse = updateRequest.Execute();
                    }
                }
            }
            MessageBox.Show("The data has been uploaded to Google Sheets from SQL Server.");
        }
        public void UpdateChecklistDueDate()
        {
            try
            {
                // Check if ChecklistID is assigned
                if (string.IsNullOrEmpty(this.checklistID))
                {
                    MessageBox.Show("Checklist ID is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Connect to the database
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    // Query to get the maximum DueDate from the ChecklistItems
                    string query = @"
                    SELECT MAX(DueDate) AS MaxDueDate
                    FROM ChecklistItem
                    WHERE ChecklistID = @ChecklistID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ChecklistID", this.checklistID);

                        // Execute the query to get the maximum DueDate
                        var result = command.ExecuteScalar();
                        DateTime? maxDueDate = result != DBNull.Value ? (DateTime?)result : null;

                        if (maxDueDate.HasValue)
                        {
                            // Update Checklist's DueDate if any item has a later DueDate
                            string updateQuery = @"
                                UPDATE Checklist
                                SET DueDate = @MaxDueDate
                                WHERE ChecklistID = @ChecklistID";

                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@MaxDueDate", maxDueDate.Value);
                                updateCommand.Parameters.AddWithValue("@ChecklistID", this.checklistID);

                                int rowsAffected = updateCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadChecklistInfo();
            }
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            UploadSQLServerToSheet();
            UpdateChecklistDueDate();
            LoadChecklistItem();
        }
        private void btnReceiveResponse_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ Google Sheets
            DataTable googleSheetData = GetDataFromGoogleSheet();

            // Đẩy dữ liệu vào SQL Server
            UploadDataToSqlServer(googleSheetData);

            FormHome formHome = new FormHome();
            formHome.UpdateDatabaseFromGoogleSheet();

            LoadChecklistItem();
            MessageBox.Show("Receive response successful!");
        }

        public void DeleteRowFromGoogleSheet(string itemId)
        {
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GetGoogleCredential(),
                ApplicationName = ApplicationName,
            });

            var range = $"{SheetName}!A:F";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null)
            {
                for (int i = 1; i < values.Count; i++)
                {
                    if (values[i][0].ToString() == itemId)
                    {
                        // Tạo yêu cầu để xóa dòng
                        var deleteRequest = new Google.Apis.Sheets.v4.Data.BatchUpdateSpreadsheetRequest
                        {
                            Requests = new List<Google.Apis.Sheets.v4.Data.Request>
                                {
                                    new Google.Apis.Sheets.v4.Data.Request
                                        {
                                            DeleteDimension = new Google.Apis.Sheets.v4.Data.DeleteDimensionRequest
                                            {
                                                Range = new Google.Apis.Sheets.v4.Data.DimensionRange
                                                {
                                                    SheetId = 0, // Thay thế bằng SheetId của bạn nếu có
                                                    Dimension = "ROWS",
                                                    StartIndex = i,
                                                    EndIndex = i + 1
                                                }
                                            }
                                        }
                                    }
                        };

                        service.Spreadsheets.BatchUpdate(deleteRequest, SpreadsheetId).Execute();
                        break;
                    }
                }
            }
            UpdateChecklistDueDate();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có item nào được chọn trong DataGridView không
            if (dgvChecklistItem.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            // Lấy ItemID từ dòng được chọn
            int selectedRowIndex = dgvChecklistItem.SelectedRows[0].Index;
            DataGridViewRow selectedRow = dgvChecklistItem.Rows[selectedRowIndex];
            string itemId = selectedRow.Cells["ItemID"].Value.ToString().Trim();

            // Xác nhận hành động xóa
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Kết nối đến cơ sở dữ liệu để thực hiện xóa
                //using (SqlConnection connection = new SqlConnection("Data Source=MSIBRAVO15\\QUOCDUY;Initial Catalog=CHECKLIST;Integrated Security=True"))
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    // Truy vấn để xóa checklist item
                    string query = "DELETE FROM ChecklistItem WHERE ItemID = @ItemID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemID", itemId);

                        // Thực hiện lệnh xóa
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("The item has been successfully deleted.");
                            DeleteRowFromGoogleSheet(itemId);
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while deleting the item.");
                        }
                    }
                }
                // Tải lại danh sách checklist items sau khi xóa
                LoadChecklistItem();
            }
        }
        public void UpdateRowInGoogleSheet(DataRow row)
        {
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GetGoogleCredential(),
                ApplicationName = ApplicationName,
            });

            // Lấy dữ liệu hiện tại từ Google Sheets
            var range = $"{SheetName}!A1:G"; // Phạm vi toàn bộ dữ liệu
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            if (values == null || values.Count < 2)
            {
                MessageBox.Show("No data found in Google Sheets.");
                return;
            }

            // Tìm dòng cần ghi đè
            int rowIndexToUpdate = -1;
            for (int i = 1; i < values.Count; i++)
            {
                if (values[i][0].ToString().Trim() == row["ItemID"].ToString().Trim()) // So sánh ItemID
                {
                    rowIndexToUpdate = i;
                    break;
                }
            }

            if (rowIndexToUpdate == -1)
            {
                return;
            }

            // Chuẩn bị dữ liệu cập nhật
            var updatedValues = new List<object>
            {
                row["ItemID"].ToString().Trim(),
                row["ChecklistID"].ToString(),
                row["TaskDescription"].ToString(),
                (row["IsCompleted"] is bool completed && completed) ? "1" : "0", // Chuyển thành 1 hoặc 0
                row["CreateDate"].ToString(),
                row["DueDate"].ToString(),
                row["EmployeeID"].ToString()
            };

            // Tạo yêu cầu cập nhật
            var updateRange = $"{SheetName}!A{rowIndexToUpdate + 1}:G{rowIndexToUpdate + 1}";
            var valueRange = new Google.Apis.Sheets.v4.Data.ValueRange
            {
                Values = new List<IList<object>> { updatedValues }
            };

            var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, updateRange);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var updateResponse = updateRequest.Execute();

            MessageBox.Show("The data has been updated on Google Sheets.");
        }

        public DataRow GetUpdatedChecklistItem(string itemID)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM ChecklistItem WHERE ItemID = @ItemID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemID", itemID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            return dataTable.Rows[0];
                        }
                    }
                }
            }
            return null;
        }

        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            if (dgvChecklistItem.SelectedRows.Count > 0)
            {
                var selectedRow = dgvChecklistItem.SelectedRows[0];
                string itemID = selectedRow.Cells["ItemID"].Value.ToString().Trim();

                // Hiển thị form cập nhật
                FormUpdateChecklistItem updateChecklistItem = new FormUpdateChecklistItem(itemID, this.checklistID);
                updateChecklistItem.ShowDialog();

                // Lấy dữ liệu cập nhật từ SQL Server
                DataRow updatedRow = GetUpdatedChecklistItem(itemID);
                if (updatedRow != null)
                {
                    // Ghi đè dữ liệu lên Google Sheets
                    UpdateRowInGoogleSheet(updatedRow);
                }
                else
                {
                    MessageBox.Show("Unable to find the updated item.");
                }

                UpdateChecklistDueDate();
                LoadChecklistItem();
            }
            else
            {
                MessageBox.Show("Please select an item to update.");
            }
        }

        public DataRow GetLatestChecklistItem(string checklistID)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                string query = @"
            SELECT TOP 1 * 
            FROM ChecklistItem 
            WHERE ChecklistID = @ChecklistID 
            ORDER BY ItemID DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ChecklistID", checklistID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            return dataTable.Rows[0];
                        }
                    }
                }
            }
            return null;
        }
        public void AppendRowToGoogleSheet(DataRow row)
        {
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GetGoogleCredential(),
                ApplicationName = ApplicationName,
            });

            // Chuyển đổi IsCompleted thành 1 hoặc 0 trước khi thêm vào Google Sheets
            var isCompleted = row["IsCompleted"] is bool completed && completed ? "1" : "0";

            // Chuyển DataRow thành danh sách các giá trị
            var values = new List<object>
            {
                row["ItemID"].ToString().Trim(),
                row["ChecklistID"].ToString(),
                row["TaskDescription"].ToString(),
                isCompleted, // Sử dụng giá trị đã chuyển đổi
                row["CreateDate"] != DBNull.Value ? row["CreateDate"].ToString() : DateTime.Now.ToString("yyyy-MM-dd"), // Gán giá trị mặc định
                row["DueDate"] != DBNull.Value ? row["DueDate"].ToString() : DateTime.Now.AddDays(7).ToString("yyyy-MM-dd"),
                row["EmployeeID"].ToString()
            };

            // Tạo yêu cầu để thêm dòng vào Google Sheets
            var range = $"{SheetName}!A:F"; // Vị trí cần thêm dữ liệu
            var valueRange = new Google.Apis.Sheets.v4.Data.ValueRange
            {
                Values = new List<IList<object>> { values }
            };

            var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendResponse = appendRequest.Execute();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            FormChecklist formChecklist = new FormChecklist();
            string checklistId = this.checklistID;  

            // Truy vấn thông tin của checklist từ cơ sở dữ liệu
            var checklistInfo = GetChecklistInfo(checklistId);

            // Sử dụng thông tin trả về để xuất PDF
            string checklistTitle = checklistInfo.checklistTitle;
            string checklistDescription = checklistInfo.checklistDescription;
            string checklistStatus = checklistInfo.checklistStatus;
            string departmentName = checklistInfo.departmentName;
            string createdByName = checklistInfo.createdByName;

            // Lấy thông tin checklist items từ cơ sở dữ liệu
            DataTable checklistItems = formChecklist.GetChecklistItemsWithEmployeeDetails(checklistId);

            // Gọi hàm ExportChecklistItemToPDF để xuất dữ liệu ra PDF
            formChecklist.ExportChecklistItemToPDF(checklistId, checklistTitle, checklistDescription, checklistStatus, departmentName, createdByName, checklistItems);

        }

        private (string checklistId, string checklistTitle, string checklistDescription, string checklistStatus, string departmentName, string createdByName) GetChecklistInfo(string checklistId)
        {
            string connectionString = Program.connectionString;

            string query = @"
            SELECT 
                c.ChecklistID, 
                c.Title, 
                c.Description, 
                c.Status, 
                d.DepartmentName, 
                u.FullName AS CreatedByName
            FROM Checklist c
            JOIN Department d ON c.DepartmentID = d.DepartmentID
            LEFT JOIN [User] u ON c.CreatedByID = u.UserID
            WHERE c.ChecklistID = @ChecklistID";

            // Khai báo các biến để lưu kết quả truy vấn
            string checklistTitle = string.Empty;
            string checklistDescription = string.Empty;
            string checklistStatus = string.Empty;
            string departmentName = string.Empty;
            string createdByName = string.Empty;

            // Truy vấn cơ sở dữ liệu và lấy kết quả
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ChecklistID", checklistId);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            checklistTitle = reader["Title"].ToString();
                            checklistDescription = reader["Description"].ToString();
                            checklistStatus = reader["Status"].ToString();
                            departmentName = reader["DepartmentName"].ToString();
                            createdByName = reader["CreatedByName"].ToString();
                        }
                    }
                }
            }

            // Trả về kết quả dưới dạng tuple
            return (checklistId, checklistTitle, checklistDescription, checklistStatus, departmentName, createdByName);
        }


    }
}
