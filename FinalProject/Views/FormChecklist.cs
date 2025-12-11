using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QRCoder;
using System.IO;
using static System.Net.WebRequestMethods;
using Guna.UI2.WinForms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using static FinalProject.Views.FormReport;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Collections;
using System.Data.Common;
using FinalProject.Models;

namespace FinalProject.Views
{
    public partial class FormChecklist : Form, ILocalizable
    {

        String connectionString = @Program.connectionString;

        public FormChecklist()
        {
            InitializeComponent();
            btnInfomation.Enabled = false;
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            lblChecklists.Text = LanguageManager.Translate("checklists");
            lblDepartment.Text = LanguageManager.Translate("department");
            lblStatus.Text = LanguageManager.Translate("status");
            btnAll.Text = LanguageManager.Translate("all");
            btnOpen.Text = LanguageManager.Translate("open");
            btnInprogress.Text = LanguageManager.Translate("inprogress");
            btnComplete.Text = LanguageManager.Translate("complete");
            btnClosed.Text = LanguageManager.Translate("closed");
            lblCreateDate.Text = LanguageManager.Translate("create_date");
            lblDue.Text = LanguageManager.Translate("due_date");
            btnAllTime.Text = LanguageManager.Translate("btnAllTime");
            lblSearch.Text = LanguageManager.Translate("search");
            btnInfomation.Text = LanguageManager.Translate("details");
            btnReload.Text = LanguageManager.Translate("reload");
            btnUpdate.Text = LanguageManager.Translate("update");
            btnDelete.Text = LanguageManager.Translate("delete");
            btnQRCode.Text = LanguageManager.Translate("qrcode");
            btnExportAll.Text = LanguageManager.Translate("exportall");
            btnFilter.Text = LanguageManager.Translate("filter");

            if (dgvChecklist != null && dgvChecklist.Columns.Count > 0)
            {
                foreach (DataGridViewColumn column in dgvChecklist.Columns)
                {
                    switch (column.Name)
                    {
                        case "CreatedByID":
                            column.HeaderText = LanguageManager.Translate("created_by_id");
                            //column.Visible = false; 
                            break;
                        case "ChecklistID_Title":
                            column.HeaderText = LanguageManager.Translate("checklist_id_title");
                            break;
                        case "CreatedByName":
                            column.HeaderText = LanguageManager.Translate("created_by_name");
                            break;
                        case "ChecklistID":
                            column.HeaderText = LanguageManager.Translate("checklist_id");
                            //column.Visible = false; 
                            break;
                        case "Title":
                            column.HeaderText = LanguageManager.Translate("title");
                            break;
                        default:
                            // Đối với các cột không được định nghĩa, giữ nguyên
                            break;
                    }
                }
            }
        }

        private void UpdateButtonColors_1(Guna.UI2.WinForms.Guna2Button selectedButton)
        {
            foreach (Control control in selectedButton.Parent.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2Button button &&
                    (button == btnAll || button == btnOpen || button == btnComplete || button == btnInprogress || button == btnClosed))
                {
                    button.FillColor = Color.Transparent;
                    button.ForeColor = Color.Black;
                }
            }

            selectedButton.FillColor = Color.FromArgb(3, 76, 172);
            selectedButton.ForeColor = Color.White;
        }

        private void Checklist_Load(object sender, EventArgs e)
        {
            LoadChecklist();
            LoadDepartment();
            btnAll.Click += (s, args) => UpdateButtonColors_1(btnAll);
            btnOpen.Click += (s, args) => UpdateButtonColors_1(btnOpen);
            btnComplete.Click += (s, args) => UpdateButtonColors_1(btnComplete);
            btnInprogress.Click += (s, args) => UpdateButtonColors_1(btnInprogress);
            btnClosed.Click += (s, args) => UpdateButtonColors_1(btnClosed);
            dgvChecklist.SelectionChanged += DataGridView_checklist_SelectionChanged;
        }

        private void LoadDepartment()
        {
            string query = "SELECT DepartmentID, DepartmentName FROM Department";

            // Nếu không phải giám đốc, chỉ lấy phòng ban của người dùng
            if (!UserSession.IsDirector)
            {
                query += " WHERE DepartmentID = @UserDepartmentID";
            }

            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataSet dataSet = new DataSet();

                if (!UserSession.IsDirector)
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@UserDepartmentID", UserSession.DepartmentID);
                }

                connection.Open();
                dataAdapter.Fill(dataSet, "Department");

                DataTable departmentTable = dataSet.Tables["Department"];

                // Nếu là giám đốc, thêm item "All"
                if (UserSession.IsDirector)
                {
                    DataRow allRow = departmentTable.NewRow();
                    allRow["DepartmentID"] = DBNull.Value;
                    allRow["DepartmentName"] = "All";
                    departmentTable.Rows.InsertAt(allRow, 0);
                }

                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.ValueMember = "DepartmentID";
                cmbDepartment.DataSource = departmentTable;
                cmbDepartment.SelectedIndex = 0;
            }
        }


        private void guna2ComboBox_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedValue == null || cmbDepartment.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return; // Nếu không có mục hợp lệ được chọn thì thoát hàm
            }

            // Lấy ID phòng ban đã chọn
            string selectedDepartmentId = cmbDepartment.SelectedValue.ToString();

            // Kiểm tra phân quyền trước khi tải dữ liệu
            if (!UserSession.IsDirector && selectedDepartmentId != UserSession.DepartmentID.ToString())
            {
                MessageBox.Show("Bạn không có quyền xem dữ liệu của phòng ban này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi hàm LoadChecklist với phòng ban đã chọn
            LoadChecklist(departmentId: selectedDepartmentId);
        }

        private void UpdateCompleteDate()
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                // Truy vấn lấy danh sách Checklist có trạng thái "Complete"
                string getChecklistsQuery = @"
                SELECT ChecklistID
                FROM Checklist
                WHERE Status = 'Complete'";

                // Lưu trữ danh sách ChecklistID
                List<string> checklistIDs = new List<string>();
                using (SqlCommand getChecklistsCommand = new SqlCommand(getChecklistsQuery, connection))
                using (SqlDataReader reader = getChecklistsCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        checklistIDs.Add(reader["ChecklistID"].ToString());
                        //MessageBox.Show(reader["ChecklistID"].ToString());
                    }
                }

                // Mở lại kết nối để thực thi các truy vấn khác
                connection.Open();

                // Lặp qua danh sách ChecklistID
                foreach (string checklistID in checklistIDs)
                {
                    // Tìm CompletionDate lớn nhất từ ChecklistItem liên quan
                    string getMaxCompletionDateQuery = @"
                    SELECT MAX(CompletionDate) AS LatestCompletionDate
                    FROM ChecklistItem
                    WHERE ChecklistID = @ChecklistID AND CompletionDate IS NOT NULL";

                    DateTime? latestCompletionDate = null;
                    using (SqlCommand getMaxDateCommand = new SqlCommand(getMaxCompletionDateQuery, connection))
                    {
                        getMaxDateCommand.Parameters.AddWithValue("@ChecklistID", checklistID);
                        var result = getMaxDateCommand.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            latestCompletionDate = (DateTime?)result;
                        }
                    }

                    // Nếu tìm thấy CompletionDate lớn nhất, cập nhật vào Checklist
                    if (latestCompletionDate.HasValue)
                    {
                        string updateCompleteDateQuery = @"
                        UPDATE Checklist
                        SET CompleteDate = @CompleteDate
                        WHERE ChecklistID = @ChecklistID";

                        using (SqlCommand updateCommand = new SqlCommand(updateCompleteDateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@CompleteDate", latestCompletionDate.Value);
                            updateCommand.Parameters.AddWithValue("@ChecklistID", checklistID);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        private void LoadChecklist(string status = null, string departmentId = null, DateTime? dueStart = null, DateTime? dueEnd = null, DateTime? createStart = null, DateTime? createEnd = null)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                // Tạo câu lệnh SQL chính
                string query =
                    "SELECT c.ChecklistID, " +
                    "       c.Title, " +
                    "       TRIM(c.ChecklistID) + ' - ' + c.Title AS ChecklistID_Title, " +
                    "       MAX(CAST(c.Description AS NVARCHAR(MAX))) AS Description, " +
                    "       MAX(d.DepartmentName) AS DepartmentName, " +
                    "       MAX(u.FullName) AS CreatedByName, " +
                    "       c.CreatedByID, " +
                    "       c.CreatedDate, " +
                    "       c.DueDate, " +
                    "       c.CompleteDate, " +
                    "       c.Status " +
                    "FROM Checklist c " +
                    "INNER JOIN Department d ON c.DepartmentID = d.DepartmentID " +
                    "INNER JOIN [User] u ON c.CreatedByID = u.UserID ";

                // Danh sách điều kiện WHERE
                List<string> conditions = new List<string>();
                if (!UserSession.IsDirector) // Nếu không phải giám đốc
                {
                    conditions.Add("c.DepartmentID = @UserDepartmentID");
                }

                if (!string.IsNullOrEmpty(status))
                {
                    conditions.Add("c.Status = @Status");
                }
                if (!string.IsNullOrEmpty(departmentId))
                {
                    conditions.Add("c.DepartmentID = @DepartmentID");
                }
                if (dueStart.HasValue && dueEnd.HasValue)
                {
                    conditions.Add("c.DueDate BETWEEN @DueStart AND @DueEnd");
                }
                if (createStart.HasValue && createEnd.HasValue)
                {
                    conditions.Add("c.CreatedDate BETWEEN @CreateStart AND @CreateEnd");
                }

                // Gắn điều kiện WHERE nếu có
                if (conditions.Count > 0)
                {
                    query += "WHERE " + string.Join(" AND ", conditions) + " ";
                }

                // Thêm GROUP BY
                query +=
                    "GROUP BY c.ChecklistID, " +
                    "         c.Title, " +
                    "         c.CreatedByID, " +
                    "         c.CreatedDate, " +
                    "         c.CompleteDate, " +
                    "         c.DueDate, " +
                    "         c.Status";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    if (!UserSession.IsDirector)
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@UserDepartmentID", UserSession.DepartmentID);
                    }
                    // Gán tham số nếu có
                    if (!string.IsNullOrEmpty(status))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@Status", status);
                    }
                    if (!string.IsNullOrEmpty(departmentId))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@DepartmentID", departmentId);
                    }
                    if (dueStart.HasValue && dueEnd.HasValue)
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@DueStart", dueStart.Value);
                        adapter.SelectCommand.Parameters.AddWithValue("@DueEnd", dueEnd.Value);
                    }
                    if (createStart.HasValue && createEnd.HasValue)
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@CreateStart", createStart.Value);
                        adapter.SelectCommand.Parameters.AddWithValue("@CreateEnd", createEnd.Value);
                    }

                    // Lấy dữ liệu và gán vào DataTable
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Gắn dữ liệu vào DataGridView
                    dgvChecklist.DataSource = dataTable;

                    // Tùy chỉnh hiển thị DataGridView
                    dgvChecklist.Columns["CreatedByID"].Visible = false; // Ẩn cột không cần thiết
                    dgvChecklist.Columns["ChecklistID_Title"].HeaderText = "Checklist ID - Title";
                    dgvChecklist.Columns["CreatedByName"].HeaderText = "Created By";
                    dgvChecklist.Columns["ChecklistID"].Visible = false;
                    dgvChecklist.Columns["Title"].Visible = false;
                }
            }
        }
        private void dtpCreateDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị ngày tạo từ DateTimePicker
                DateTime createDate = dtpCreateDate.Value;
                // Kiểm tra nếu ngày tạo mới nhỏ hơn ngày hết hạn hiện tại
                if (createDate > dtpDueDate.Value)
                {
                    // Nếu ngày tạo mới lớn hơn ngày hết hạn, giữ nguyên ngày hết hạn
                    dtpDueDate.Value = createDate;
                }

                // Cập nhật lại min date của dtpDueDate sao cho không thể chọn ngày trước ngày tạo
                dtpDueDate.MinDate = createDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị ngày hết hạn từ DateTimePicker
                DateTime dueDate = dtpDueDate.Value;
                DateTime createDate = dtpCreateDate.Value;
                string selectedDepartmentId = cmbDepartment.SelectedIndex != 0 ? cmbDepartment.SelectedValue.ToString() : null;

                // Kiểm tra nếu ngày hết hạn được chọn nhỏ hơn ngày tạo, thì đặt lại giá trị ngày hết hạn về ngày tạo
                if (dueDate < createDate)
                {
                    dtpDueDate.Value = createDate;
                }

                // Gọi hàm LoadChecklist với phạm vi ngày hết hạn (dueStart và dueEnd là ngày hết hạn)
                LoadChecklist(departmentId: selectedDepartmentId, dueStart: createDate, dueEnd: dueDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string status = string.Empty;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            string selectedDepartmentId = cmbDepartment.SelectedIndex != 0 ? cmbDepartment.SelectedValue.ToString() : null;
            status = "Open";
            LoadChecklist("Open", selectedDepartmentId);
        }

        private void btnInprogress_Click(object sender, EventArgs e)
        {
            string selectedDepartmentId = cmbDepartment.SelectedIndex != 0 ? cmbDepartment.SelectedValue.ToString() : null;
            status = "In progress";
            LoadChecklist("In progress", selectedDepartmentId);
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            string selectedDepartmentId = cmbDepartment.SelectedIndex != 0 ? cmbDepartment.SelectedValue.ToString() : null;
            status = "Complete";
            LoadChecklist("Complete", selectedDepartmentId);
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            string selectedDepartmentId = cmbDepartment.SelectedIndex != 0 ? cmbDepartment.SelectedValue.ToString() : null;
            LoadChecklist("Closed", selectedDepartmentId);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            string selectedDepartmentId = cmbDepartment.SelectedIndex != 0 ? cmbDepartment.SelectedValue.ToString() : null;
            LoadChecklist(departmentId: selectedDepartmentId);
        }

        private void DataGridView_checklist_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgvChecklist.SelectedRows.Count > 0)
            {
                btnInfomation.Enabled = true; // Bật nút nếu có dòng được chọn
            }
            else
            {
                btnInfomation.Enabled = false; // Tắt nút nếu không có dòng nào được chọn
            }
        }

        private void btnInfomation_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvChecklist.SelectedRows.Count > 0)
            {
                // Lấy hàng đã chọn
                var selectedRow = dgvChecklist.SelectedRows[0];

                // Lấy ChecklistID từ hàng đã chọn
                string checklistId = selectedRow.Cells["ChecklistID"].Value.ToString();

                // Tạo mới form ChecklistCheck
                FormChecklistItem checklistInfoForm = new FormChecklistItem(checklistId);

                // Hiển thị form
                checklistInfoForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a checklist to view the information.", "Notifacation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void DeleteChecklist(string checklistId)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                try
                {
                    // Kiểm tra xem checklist này có liên kết với các checklist items không
                    string checkQuery = "SELECT COUNT(*) FROM ChecklistItem WHERE ChecklistID = @ChecklistID";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@ChecklistID", checklistId);
                    int itemCount = (int)checkCommand.ExecuteScalar();

                    if (itemCount > 0)
                    {
                        // Nếu có các checklist items, hỏi người dùng có muốn xóa chúng không
                        DialogResult result = MessageBox.Show(
                            "This checklist has existing items. Do you want to delete them as well?",
                            "Confirm Delete Checklist Items",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            // Xóa tất cả checklist items của checklist này
                            string deleteItemsQuery = "DELETE FROM ChecklistItem WHERE ChecklistID = @ChecklistID";
                            SqlCommand deleteItemsCommand = new SqlCommand(deleteItemsQuery, connection);
                            deleteItemsCommand.Parameters.AddWithValue("@ChecklistID", checklistId);
                            deleteItemsCommand.ExecuteNonQuery();
                            MessageBox.Show("All items in the checklist have been deleted.");
                        }
                        else if (result == DialogResult.No)
                        {
                            MessageBox.Show("The checklist items are not deleted.");
                        }
                        else
                        {
                            // Nếu người dùng chọn Cancel
                            MessageBox.Show("No changes have been made.");
                            return;
                        }
                    }

                    // Xóa checklist sau khi các checklist items đã được xử lý
                    string deleteChecklistQuery = "DELETE FROM Checklist WHERE ChecklistID = @ChecklistID";
                    SqlCommand deleteChecklistCommand = new SqlCommand(deleteChecklistQuery, connection);
                    deleteChecklistCommand.Parameters.AddWithValue("@ChecklistID", checklistId);
                    int rowsAffected = deleteChecklistCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Checklist has been successfully deleted.");
                        // Cập nhật lại dữ liệu trong dataGridView
                        LoadChecklist(); // Giả sử bạn có phương thức này để tải lại dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("No checklist found with ID: " + checklistId);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    MessageBox.Show("An error occurred while deleting the checklist: " + ex.Message);
                }
            }
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvChecklist.SelectedRows.Count > 0)
            {
                // Lấy hàng đã chọn
                var selectedRow = dgvChecklist.SelectedRows[0];

                // Lấy ChecklistID từ hàng đã chọn
                string checklistId = selectedRow.Cells["ChecklistID"].Value.ToString();

                // Xác nhận trước khi xóa
                var confirmResult = MessageBox.Show("Are you sure you want to delete this checklist?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    // Gọi phương thức xóa checklist
                    DeleteChecklist(checklistId);
                }
            }
            else
            {
                MessageBox.Show("Please select a checklist to delete.");

            }
        }

        private void UpdateStatusChecklist()
        {
            // Kết nối tới cơ sở dữ liệu
            string connectionString = Program.connectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Lấy danh sách tất cả các Checklist
                string getChecklistQuery = "SELECT ChecklistID FROM Checklist";
                using (SqlCommand cmd = new SqlCommand(getChecklistQuery, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<string> checklistIds = new List<string>();

                    while (reader.Read())
                    {
                        checklistIds.Add(reader["ChecklistID"].ToString());
                    }

                    reader.Close();

                    // Cập nhật trạng thái cho từng Checklist
                    foreach (var checklistId in checklistIds)
                    {
                        string status = GetChecklistStatus(conn, checklistId);
                        UpdateChecklistStatus(conn, checklistId, status);
                    }
                }
            }
        }

        private string GetChecklistStatus(SqlConnection conn, string checklistId)
        {
            // Truy vấn để đếm tổng số item và số item chưa hoàn thành
            string totalQuery = "SELECT COUNT(*) FROM ChecklistItem WHERE ChecklistID = @ChecklistID";
            string incompleteQuery = "SELECT COUNT(*) FROM ChecklistItem WHERE ChecklistID = @ChecklistID AND IsCompleted = 0";
           
            try
            {
                using (SqlCommand cmd = new SqlCommand(totalQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ChecklistID", checklistId);
                    int totalCount = (int)cmd.ExecuteScalar(); // Đếm tổng số item
                    // Nếu không có item nào trong checklist, trạng thái là "Open"
                    if (totalCount == 0)
                    {
                        return "Open";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(incompleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ChecklistID", checklistId);
                    int incompleteCount = (int)cmd.ExecuteScalar(); // Đếm số item chưa hoàn thành
                    if (incompleteCount > 0)
                    {
                        return "In Progress";
                    }

                    // Nếu tất cả item đều hoàn thành, trạng thái là "Complete"
                    return "Complete";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "In Progress";
        }

        private void UpdateChecklistStatus(SqlConnection conn, string checklistId, string status)
        {
            try
            {
                // Câu lệnh SQL để cập nhật trạng thái và xử lý trường CompleteDate
                string updateStatusQuery = @"
                UPDATE Checklist 
                SET Status = @Status, 
                    CompleteDate = CASE 
                                    WHEN @Status = 'Complete' THEN CompleteDate 
                                    ELSE NULL 
                                  END
                WHERE ChecklistID = @ChecklistID";

                using (SqlCommand cmd = new SqlCommand(updateStatusQuery, conn))
                {
                    // Thêm tham số cho câu lệnh SQL
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@ChecklistID", checklistId);

                    // Thực hiện câu lệnh cập nhật
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi khi kết nối SQL
                MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khác
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvChecklist.SelectedRows.Count > 0)
            {
                // Lấy hàng đã chọn
                var selectedRow = dgvChecklist.SelectedRows[0];

                // Lấy ChecklistID từ hàng đã chọn
                string checklistId = selectedRow.Cells["ChecklistID"].Value.ToString();

                FormUpdateChecklist updateChecklist = new FormUpdateChecklist(checklistId);

                // Hiển thị form
                updateChecklist.ShowDialog(); // Sửa ở đây
            }
            else
            {
                MessageBox.Show("Please select a checklist to add an item.");
            }
        }
        private Bitmap GenerateQRCode()
        {
            // Tạo nội dung QR Code
            StringBuilder qrContent = new StringBuilder();
            qrContent.AppendLine("https://docs.google.com/forms/d/e/1FAIpQLScW5Ez1zOF2kCjJ2Y2FJoeGnfyszNQ8_uBWbfEkevnsW_UQqA/viewform");

            // Tạo mã QR từ nội dung
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrContent.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Mở SaveFileDialog để người dùng chọn nơi lưu QR Code
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.Title = "Save QR Code";
                saveFileDialog.FileName = $"FormResponse.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string qrFilePath = saveFileDialog.FileName;

                    qrCodeImage.Save(qrFilePath, System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            return qrCodeImage;
        }

        public DataTable GetChecklistItemsWithEmployeeDetails(string checklistId)
        {
            string query = @"
            SELECT ci.ItemID, ci.TaskDescription, ci.IsCompleted, ci.CreateDate, ci.DueDate,
                   e.EmployeeID, e.Name AS EmployeeName, d.DepartmentName AS DepartmentName
            FROM ChecklistItem ci
            LEFT JOIN ChecklistItem cie ON ci.ItemID = cie.ItemID
            LEFT JOIN Employee e ON cie.EmployeeID = e.EmployeeID
            LEFT JOIN Department d ON e.DepartmentID = d.DepartmentID
            WHERE ci.ChecklistID = @ChecklistID";

            DataTable result = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ChecklistID", checklistId);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }

        public void ExportChecklistItemToPDF(
            string checklistId,
            string checklistTitle,
            string checklistDescription,
            string checklistStatus,
            string departmentName,
            string createdByName,
            DataTable checklistItems)
        {
            // Sử dụng SaveFileDialog để cho phép người dùng chọn đường dẫn lưu file PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Save Checklist Report",
                FileName = checklistId.Trim() + ".pdf" // Mặc định tên file
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 36f, 36f, 70f, 50f);
                    // Tạo đối tượng PdfPageEvents và truyền dữ liệu
                    var pageEvents = new PdfPageEvents
                    {
                        DepartmentName = departmentName, // Truyền thông tin phòng ban
                        ReportID = $"RP{new Random().Next(1, 1000):D3}", // Truyền ReportID cố định
                        CompanyName = "BCMP" // Tên công ty (cố định hoặc lấy từ input khác nếu cần)
                    };

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    writer.PageEvent = pageEvents;
                    pdfDoc.Open();

                    // Load font
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                    BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font bodyFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);

                    // Title
                    pdfDoc.Add(new Paragraph($"Thông tin checklist: {checklistTitle}", titleFont));
                    pdfDoc.Add(new Paragraph($"\nChecklist ID: {checklistId}\nTrạng thái: {checklistStatus}\nPhòng ban: {departmentName}\nTạo bởi: {createdByName}", bodyFont));
                    pdfDoc.Add(new Paragraph("\n"));

                    // Group data by employee
                    var employeeGroups = checklistItems.AsEnumerable()
                        .GroupBy(row => new
                        {
                            EmployeeID = row["EmployeeID"].ToString().Trim(),
                            EmployeeName = row["EmployeeName"].ToString().Trim(),
                            DepartmentName = row["DepartmentName"].ToString().Trim()
                        });

                    foreach (var employeeGroup in employeeGroups)
                    {
                        string employeeID = employeeGroup.Key.EmployeeID;
                        string employeeName = employeeGroup.Key.EmployeeName;
                        string department = employeeGroup.Key.DepartmentName;

                        // Employee header
                        pdfDoc.Add(new Paragraph($"{employeeID} - {employeeName} - {department}", headerFont));
                        pdfDoc.Add(new Paragraph("\n"));

                        // Table for checklist items
                        PdfPTable pdfTable = new PdfPTable(5) { WidthPercentage = 100 }; // Columns: ChecklistItemID, Task, Status, CreateDate, DueDate
                        pdfTable.SetWidths(new float[] { 15f, 35f, 15f, 20f, 20f });

                        // Add table headers
                        string[] columnHeaders = { "ID", "Mô tả", "Trạng thái", "Ngày tạo", "Deadline" };
                        foreach (string header in columnHeaders)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(header, headerFont))
                            {
                                BackgroundColor = BaseColor.LIGHT_GRAY,
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 5
                            };
                            pdfTable.AddCell(cell);
                        }

                        // Add rows
                        foreach (var row in employeeGroup)
                        {
                            // ChecklistItemID - Task
                            pdfTable.AddCell(new Phrase(row["ItemID"].ToString(), bodyFont));
                            pdfTable.AddCell(new Phrase(row["TaskDescription"].ToString(), bodyFont));

                            // Status
                            string status = (bool)row["IsCompleted"] ? "Completed" : "Incomplete";
                            pdfTable.AddCell(new Phrase(status, bodyFont));

                            // CreateDate
                            pdfTable.AddCell(new Phrase(row["CreateDate"].ToString(), bodyFont));

                            // DueDate
                            pdfTable.AddCell(new Phrase(row["DueDate"].ToString(), bodyFont));
                        }

                        pdfDoc.Add(pdfTable);
                        pdfDoc.Add(new Paragraph("\n"));
                    }

                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("Export completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ExportAllChecklistsToPDF()
        {
            // Sử dụng SaveFileDialog để cho phép người dùng chọn đường dẫn lưu file PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Save Checklist Report",
                FileName = "All_Checklists_Report.pdf" // Mặc định tên file
            };

            // Kiểm tra nếu người dùng chọn đường dẫn và tên file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string reportID = $"PCCV{new Random().Next(1, 1000):D3}";

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 36f, 36f, 70f, 50f);
                    // Tạo đối tượng PdfPageEvents và truyền dữ liệu
                    var pageEvents = new PdfPageEvents
                    {
                        DepartmentName = "All department", // Truyền thông tin phòng ban
                        ReportID = reportID, // Truyền ReportID cố định
                        CompanyName = "BCMP" // Tên công ty (cố định hoặc lấy từ input khác nếu cần)
                    };
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    writer.PageEvent = pageEvents;
                    pdfDoc.Open();

                    // Load font
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                    BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font bodyFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);

                    // Lặp qua từng dòng trong DataGridView
                    foreach (DataGridViewRow row in dgvChecklist.Rows)
                    {
                        if (row.IsNewRow) continue; // Bỏ qua dòng mới

                        // Lấy thông tin từ DataGridView
                        string checklistId = row.Cells["ChecklistID"].Value.ToString();
                        string checklistTitle = row.Cells["Title"].Value.ToString();
                        string checklistDescription = row.Cells["Description"].Value.ToString();
                        string checklistStatus = row.Cells["Status"].Value.ToString();
                        string departmentName = row.Cells["DepartmentName"].Value.ToString();
                        string createdByName = row.Cells["CreatedByName"].Value.ToString();
                        string createDate = row.Cells["CreatedDate"].Value.ToString();
                        string dueDate = row.Cells["DueDate"].Value.ToString();

                        // Thêm tiêu đề checklist
                        pdfDoc.Add(new Paragraph($"Checklist: {checklistTitle}", titleFont));
                        pdfDoc.Add(new Paragraph($"Checklist ID: {checklistId}\nPhòng ban: {departmentName}\nTạo bởi: {createdByName}\n\nMô tả: {checklistDescription}\nTrạng thái: {checklistStatus}\nThời gian: {createDate} - {dueDate}\n\n", bodyFont));

                        // Lấy checklist items từ cơ sở dữ liệu
                        DataTable checklistItems = GetChecklistItems(checklistId);

                        // Lặp qua các checklist items và xuất ra PDF
                        PdfPTable pdfTable = new PdfPTable(6) { WidthPercentage = 100 }; // Cập nhật số cột thành 6
                        pdfTable.SetWidths(new float[] { 15f, 30f, 15f, 15f, 15f, 20f }); // Cài đặt độ rộng cột

                        // Thêm header cho bảng
                        string[] columnHeaders = { "ID", "Mô tả", "Trạng thái", "Ngày tạo", "Deadline", "Nhân viên đảm nhận" };
                        foreach (string header in columnHeaders)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(header, headerFont))
                            {
                                BackgroundColor = BaseColor.LIGHT_GRAY,
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 5
                            };
                            pdfTable.AddCell(cell);
                        }

                        // Thêm các checklist item vào bảng
                        foreach (DataRow itemRow in checklistItems.Rows)
                        {
                            // ChecklistItemID - Task
                            pdfTable.AddCell(new Phrase(itemRow["ItemID"].ToString(), bodyFont));
                            pdfTable.AddCell(new Phrase(itemRow["TaskDescription"].ToString(), bodyFont));

                            // Status
                            string status = (bool)itemRow["IsCompleted"] ? "Completed" : "Incomplete";
                            pdfTable.AddCell(new Phrase(status, bodyFont));

                            // CreateDate
                            pdfTable.AddCell(new Phrase(itemRow["CreateDate"].ToString(), bodyFont));

                            // DueDate
                            pdfTable.AddCell(new Phrase(itemRow["DueDate"].ToString(), bodyFont));

                            // Tên nhân viên đảm nhận
                            pdfTable.AddCell(new Phrase(itemRow["EmployeeName"].ToString(), bodyFont));
                        }

                        // Thêm bảng vào PDF
                        pdfDoc.Add(pdfTable);
                        pdfDoc.Add(new Paragraph("\n"));
                    }

                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("Export completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private DataTable GetChecklistItems(string checklistId)
        {
            string query = "SELECT ci.ItemID, ci.TaskDescription, ci.IsCompleted, ci.CreateDate, ci.DueDate, e.Name AS EmployeeName " +
                           "FROM ChecklistItem ci " +
                           "INNER JOIN Employee e ON ci.EmployeeID = e.EmployeeID " + // Thêm JOIN với bảng Employee
                           "WHERE ci.ChecklistID = @ChecklistID";
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@ChecklistID", checklistId);
                DataTable checklistItems = new DataTable();
                adapter.Fill(checklistItems);
                return checklistItems;
            }
        }
        public class PdfPageEvents : PdfPageEventHelper
        {
            private readonly iTextSharp.text.Image logo;
            private readonly BaseFont baseFont;
            public string DepartmentName { get; set; }
            public string ReportID { get; set; }
            public string CompanyName { get; set; } = "BCMP";

            private PdfTemplate totalPages; // Template để ghi tổng số trang

            public PdfPageEvents()
            {
                using (MemoryStream logoStream = new MemoryStream())
                {
                    Properties.Resources.Logo_Name_Transparent.Save(logoStream, System.Drawing.Imaging.ImageFormat.Png);
                    logo = iTextSharp.text.Image.GetInstance(logoStream.ToArray());
                    logo.ScaleToFit(50f, 50f);
                }

                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            }

            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                // Khởi tạo template để ghi tổng số trang
                totalPages = writer.DirectContent.CreateTemplate(50, 50);
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                PdfContentByte cb = writer.DirectContent;

                // Set up font for text
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                // HEADER
                float headerY = document.Top + 45; 
                float footerY = document.Bottom - 30;

                // Nội dung Header
                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase($"Tên BC: Báo cáo kết quả công việc", font),
                                           document.Left + 10, headerY, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase($"Số BC: {ReportID}", font), // Sử dụng ReportID cố định
                                           document.Left + 10, headerY - 12, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase($"Phòng ban: {DepartmentName}", font), // Thêm phòng ban
                                           document.Left + 10, headerY - 24, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT, new Phrase($"Công ty: {CompanyName}", font), // Thêm tên công ty
                                           document.Right - 10, headerY, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase($"Ngày tạo: {DateTime.Now:dd/MM/yyyy}", font),
                                           document.Left + 10, headerY - 36, 0);

                // Đường kẻ ngang dưới Header
                cb.MoveTo(document.Left, headerY - 40);
                cb.LineTo(document.Right, headerY - 40);
                cb.Stroke();

                // FOOTER
                // Footer separator line
                cb.MoveTo(document.Left, footerY + 30);
                cb.LineTo(document.Right, footerY + 30);
                cb.Stroke();

                // Bottom Left: Logo
                logo.SetAbsolutePosition(document.Left + 10, footerY + 5);
                cb.AddImage(logo);
                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("ver0.0", font),
                           document.Left + 10, footerY, 0);

                // Center: Page number
                int pageNumber = writer.PageNumber;
                string pageText = $"Page {pageNumber}/";

                // Đo chiều dài chuỗi "Page x/" để canh chỉnh
                float textWidth = baseFont.GetWidthPoint(pageText, 10);
                cb.BeginText();
                cb.SetFontAndSize(baseFont, 10);
                cb.SetTextMatrix((document.Left + document.Right) / 2 - textWidth / 2, footerY + 15);
                cb.ShowText(pageText);
                cb.EndText();

                // Thêm template để chèn tổng số trang sau
                cb.AddTemplate(totalPages, (document.Left + document.Right) / 2 + textWidth / 2, footerY + 15);

                // Bottom Right: Report creation timestamp
                string currentTime = $"This report was created at {DateTime.Now:dd/MM/yyyy HH:mm}";
                ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT, new Phrase(currentTime, font),
                                           document.Right - 10, footerY + 15, 0);
            }

            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                // Ghi tổng số trang vào template
                totalPages.BeginText();
                totalPages.SetFontAndSize(baseFont, 10);
                totalPages.SetTextMatrix(0, 0);
                totalPages.ShowText($"{writer.PageNumber}");
                totalPages.EndText();
            }
        }


        private void btnQRCode_Click(object sender, EventArgs e)
        {
            if (dgvChecklist.SelectedRows.Count > 0)
            {
                var selectedRow = dgvChecklist.SelectedRows[0];

                // Lấy dữ liệu từ các cột trong DataGridView
                string checklistId = selectedRow.Cells["ChecklistID"].Value.ToString();
                string checklistTitle = selectedRow.Cells["Title"].Value.ToString();
                string departmentName = selectedRow.Cells["DepartmentName"].Value.ToString();

                // Gọi hàm tạo QR Code và PDF
                Bitmap qrCodeImage = GenerateQRCode();
                FormQRCodeDisplay qrDisplayForm = new FormQRCodeDisplay(qrCodeImage, checklistId, checklistTitle);
                qrDisplayForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a checklist to generate the QR code and PDF.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Lưu QR Code vào file và hiển thị
        private void SaveAndDisplayQRCode(Bitmap qrCodeImage, string fileName)
        {
            // Đường dẫn lưu QR Code
            string folderPath = Path.Combine(Application.StartupPath, "QRCode");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Lưu file QR Code
            string filePath = Path.Combine(folderPath, $"{fileName}.png");
            qrCodeImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

            // Hiển thị file QR Code trong PictureBox
            PictureBox pictureBox = new PictureBox
            {
                Image = qrCodeImage,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill
            };

            // Mở form hiển thị QR Code
            Form qrCodeForm = new Form
            {
                Text = "QR Code",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            qrCodeForm.Controls.Add(pictureBox);
            qrCodeForm.ShowDialog();

            // Thông báo lưu thành công
            MessageBox.Show($"QR Code has been saved to: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    // Khởi tạo câu truy vấn cơ bản
                    string query = @"
                SELECT c.ChecklistID, c.Title, 
                       TRIM(c.ChecklistID) + ' - ' + c.Title AS ChecklistID_Title, 
                       c.Description, d.DepartmentName, u.FullName AS CreatedByName,
                       c.CreatedByID, c.CreatedDate, c.DueDate, c.CompleteDate, c.Status
                FROM Checklist c
                INNER JOIN Department d ON c.DepartmentID = d.DepartmentID
                INNER JOIN [User] u ON c.CreatedByID = u.UserID
                LEFT JOIN ChecklistItem ci ON ci.ChecklistID = c.ChecklistID";

                    // Nếu có nội dung tìm kiếm, thêm điều kiện WHERE
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        query += @"
                            WHERE (LOWER(c.Title) LIKE @SearchText
                           OR LOWER(u.FullName) LIKE @SearchText
                           OR LOWER(ci.ItemID) LIKE @SearchText
                           OR LOWER(c.ChecklistID) LIKE @SearchText)";
                    }

                    // Nếu không phải giám đốc, thêm điều kiện phòng ban
                    if (!UserSession.IsDirector)
                    {
                        query += string.IsNullOrEmpty(searchText)
                            ? " WHERE c.DepartmentID = @UserDepartmentID"
                            : " AND c.DepartmentID = @UserDepartmentID";
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Gắn tham số tìm kiếm nếu cần
                        if (!string.IsNullOrEmpty(searchText))
                        {
                            adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                        }

                        if (!UserSession.IsDirector)
                        {
                            adapter.SelectCommand.Parameters.AddWithValue("@UserDepartmentID", UserSession.DepartmentID);
                        }

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị kết quả hoặc xóa dữ liệu nếu không có gì
                        if (dataTable.Rows.Count > 0)
                        {
                            // Loại bỏ các dòng trùng lặp bằng LINQ
                            var distinctRows = dataTable.AsEnumerable()
                                .GroupBy(row => new
                                {
                                    ChecklistID = row["ChecklistID"],
                                    Title = row["Title"],
                                    ChecklistID_Title = row["ChecklistID_Title"],
                                    Description = row["Description"],
                                    DepartmentName = row["DepartmentName"],
                                    CreatedByName = row["CreatedByName"],
                                    CreatedByID = row["CreatedByID"],
                                    CreatedDate = row["CreatedDate"],
                                    DueDate = row["DueDate"],
                                    CompleteDate = row["CompleteDate"],
                                    Status = row["Status"]
                                })
                                .Select(group => group.First())
                                .CopyToDataTable();

                            dgvChecklist.DataSource = distinctRows;
                        }
                        else
                        {
                            dgvChecklist.DataSource = null;
                        }

                        CustomizeChecklistGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CustomizeChecklistGrid()
        {
            try
            {
                if (dgvChecklist.Columns.Contains("CreatedByID"))
                    dgvChecklist.Columns["CreatedByID"].Visible = false;

                if (dgvChecklist.Columns.Contains("ChecklistID"))
                    dgvChecklist.Columns["ChecklistID"].Visible = false;

                if (dgvChecklist.Columns.Contains("Title"))
                    dgvChecklist.Columns["Title"].Visible = false;

                if (dgvChecklist.Columns.Contains("ChecklistID_Title"))
                    dgvChecklist.Columns["ChecklistID_Title"].HeaderText = "Checklist ID - Title";

                if (dgvChecklist.Columns.Contains("CreatedByName"))
                    dgvChecklist.Columns["CreatedByName"].HeaderText = "Created By";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            UpdateStatusChecklist();
            UpdateCompleteDate();
            LoadChecklist();
        }
        private void btnAllTime_Click(object sender, EventArgs e)
        {
            string selectedDepartmentId = cmbDepartment.SelectedIndex != 0 ? cmbDepartment.SelectedValue.ToString() : null;
            LoadChecklist(departmentId: selectedDepartmentId);
        }
        private void btnExportAll_Click(object sender, EventArgs e)
        {
            ExportAllChecklistsToPDF();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị ngày tạo từ DateTimePicker
                DateTime createDate = dtpCreateDate.Value;
                // Kiểm tra nếu ngày tạo mới nhỏ hơn ngày hết hạn hiện tại
                if (createDate > dtpDueDate.Value)
                {
                    // Nếu ngày tạo mới lớn hơn ngày hết hạn, giữ nguyên ngày hết hạn
                    dtpDueDate.Value = createDate;
                }

                // Cập nhật lại min date của dtpDueDate sao cho không thể chọn ngày trước ngày tạo
                dtpDueDate.MinDate = createDate;

                // Lấy giá trị ngày hết hạn từ DateTimePicker
                DateTime dueDate = dtpDueDate.Value;
                string selectedDepartmentId = cmbDepartment.SelectedIndex != 0 ? cmbDepartment.SelectedValue.ToString() : null;

                // Kiểm tra nếu ngày hết hạn được chọn nhỏ hơn ngày tạo, thì đặt lại giá trị ngày hết hạn về ngày tạo
                if (dueDate < createDate)
                {
                    dtpDueDate.Value = createDate;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                string selectedDepartmentId = cmbDepartment.SelectedIndex != 0 ? cmbDepartment.SelectedValue.ToString() : null;
                DateTime createDate = dtpCreateDate.Value;
                DateTime dueDate = dtpDueDate.Value;
                if (status != null)
                {
                    LoadChecklist(departmentId: selectedDepartmentId, dueStart: createDate, dueEnd: dueDate, status: status);
                }
                LoadChecklist(departmentId: selectedDepartmentId, dueStart: createDate, dueEnd: dueDate);
            }
        }
    }
}