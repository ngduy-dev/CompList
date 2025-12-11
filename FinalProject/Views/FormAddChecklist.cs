using FinalProject.Models;
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

namespace FinalProject.Views
{
    public partial class FormAddChecklist : Form, ILocalizable
    {
        public FormAddChecklist()
        {
            InitializeComponent();
            LoadDepartmentsIntoComboBox();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            this.Text = LanguageManager.Translate("add_checklist_title");
            lblAddChecklist.Text = LanguageManager.Translate("add_checklist");
            lblTitle.Text = LanguageManager.Translate("title");
            txtDescription.Text = LanguageManager.Translate("description");
            lblStatus.Text = LanguageManager.Translate("status");
            lblDepartment.Text = LanguageManager.Translate("assignee");
            lblDueDate.Text = LanguageManager.Translate("due_date");
            btnAddChecklist.Text = LanguageManager.Translate("btn_add_cl");
        }

        private void LoadDepartmentsIntoComboBox()
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();
                string query = "SELECT DepartmentID, DepartmentName FROM Department"; // Lấy DepartmentID và DepartmentName
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    // Tạo danh sách các phòng ban
                    var departmentList = new List<KeyValuePair<string, string>>();
                    while (reader.Read())
                    {
                        // Lưu ID và Name dưới dạng KeyValuePair
                        string departmentID = reader["DepartmentID"].ToString();
                        string departmentName = reader["DepartmentName"].ToString();
                        departmentList.Add(new KeyValuePair<string, string>(departmentID, departmentName));
                    }

                    // Gán danh sách vào DataSource của ComboBox
                    cmbDepartment.DataSource = departmentList;
                    cmbDepartment.DisplayMember = "Value"; // Hiển thị tên phòng ban
                    cmbDepartment.ValueMember = "Key";    // Lưu ID phòng ban
                }
            }
        }


        private string GenerateChecklistID()
        {
            string newChecklistID = string.Empty;

            // Lấy giá trị ID của phòng ban được chọn
            string departmentID = ((KeyValuePair<string, string>)cmbDepartment.SelectedItem).Key;

            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                // Truy vấn để lấy giá trị lớn nhất từ phần số sau "_CHK"
                string query = @"
                SELECT MAX(CAST(SUBSTRING(ChecklistID, LEN(ChecklistID) - 2, 3) AS INT)) 
                FROM Checklist
                WHERE ChecklistID LIKE @DepartmentID + '-CHK%'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DepartmentID", departmentID.Trim());

                    object result = command.ExecuteScalar();

                    // Nếu không có checklist nào, bắt đầu từ 109
                    int maxId = result != DBNull.Value ? Convert.ToInt32(result) : 108;

                    // Định dạng ID mới: Mã phòng ban + '-CHK' + số từ 109 trở đi
                    newChecklistID = departmentID.Trim() + "-CHK" + (maxId + 1).ToString("D3");
                }
            }

            return newChecklistID;
        }


        private void buttonAddChecklist_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            string status = cboStatus.SelectedItem?.ToString();
            string createdByID = UserSession.UserID; // Gán mặc định UserID của người dùng hiện tại
            DateTime dueDate = dtpDueDate.Value;
            string departmentID = (cmbDepartment.SelectedItem as dynamic)?.Key; // Lấy ID của phòng ban đã chọn
            if (!UserSession.IsDirector && departmentID != UserSession.DepartmentID)
            {
                MessageBox.Show("You cannot add a checklist for another department.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra nếu DueDate trước ngày hiện tại
            if (dueDate.Date < DateTime.Today)
            {
                MessageBox.Show("Due date cannot be before today.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trạng thái người dùng trong phòng ban
            if (!CheckUsersActiveInDepartment(departmentID))
            {
                MessageBox.Show("This department are inactive. You cannot add a checklist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực hiện thêm checklist vào cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();
                string query = @"
            INSERT INTO Checklist (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID)
            VALUES (@ChecklistID, @Title, @Description, @CreatedByID, GETDATE(), @DueDate, @Status, @DepartmentID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    string checklistId = GenerateChecklistID(); // Gọi hàm tạo ID tự động
                    command.Parameters.AddWithValue("@ChecklistID", checklistId);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@CreatedByID", createdByID); // Sử dụng UserSession.UserID
                    command.Parameters.AddWithValue("@DueDate", dueDate);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@DepartmentID", departmentID);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Checklist added successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Hàm kiểm tra tất cả người dùng trong phòng ban có bị vô hiệu hóa không
        private bool CheckUsersActiveInDepartment(string departmentID)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [User] WHERE DepartmentID = @DepartmentID AND IsActive = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DepartmentID", departmentID);
                    int activeUsersCount = (int)command.ExecuteScalar();

                    // Nếu có ít nhất một người dùng còn active thì trả về true
                    return activeUsersCount > 0;
                }
            }
        }


    }
}
