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
    public partial class FormDepartment : Form, ILocalizable
    {
        public FormDepartment()
        {
            InitializeComponent();
            LoadDepartmentData();
        }
        private void Department_Load(object sender, EventArgs e)
        {
            LoadDepartmentData();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            lblTitleDepartment.Text = LanguageManager.Translate("departments");
            lblSearch.Text = LanguageManager.Translate("search");
            btnReload.Text = LanguageManager.Translate("reload");
            btnAdd.Text = LanguageManager.Translate("addnewdep");
            btnBlock.Text = LanguageManager.Translate("blockdep");
            btnUnlock.Text = LanguageManager.Translate("unblockdep");
            //if (dtgDepartment.Columns.Count > 0)
            //{
            //    dtgDepartment.Columns["DepartmentID"].HeaderText = LanguageManager.Translate("department_id");
            //    dtgDepartment.Columns["DepartmentName"].HeaderText = LanguageManager.Translate("department_name");
            //    dtgDepartment.Columns["ManagerName"].HeaderText = LanguageManager.Translate("department_head");
            //    dtgDepartment.Columns["ManagerEmail"].HeaderText = LanguageManager.Translate("department_head_email");
            //    dtgDepartment.Columns["IsActive"].HeaderText = LanguageManager.Translate("is_active");
            //}
        }


        private void LoadDepartmentData()
        {
            // Chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = Program.connectionString;

            // Truy vấn SQL để lấy thông tin phòng ban và trưởng phòng
            string query = @"
            SELECT 
                d.DepartmentID,
                d.DepartmentName,
                u.FullName AS ManagerName,
                u.Email AS ManagerEmail,
                u.IsActive AS IsActive
            FROM Department d
            JOIN [User] u ON d.DepartmentID = u.DepartmentID"; // Điều kiện JOIN này cần điều chỉnh

            try
            {
                // Kết nối với cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Thực thi truy vấn SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Gán dữ liệu vào DataGridView
                            dgvDepartment.DataSource = dataTable;

                            // Tùy chỉnh header hiển thị
                            dgvDepartment.Columns["DepartmentName"].HeaderText = "Department Name";
                            dgvDepartment.Columns["ManagerName"].HeaderText = "Department Head";
                            dgvDepartment.Columns["ManagerEmail"].HeaderText = "Department Head Email";

                            // Chỉnh sửa header cột "IsActive"
                            dgvDepartment.Columns["IsActive"].HeaderText = "Is Active";


                            // Kiểm tra và định dạng giá trị "IsActive"
                            foreach (DataGridViewRow row in dgvDepartment.Rows)
                            {
                                // Lưu DepartmentID vào Tag
                                row.Tag = row.Cells["DepartmentID"].Value;

                                if (row.Cells["IsActive"].Value != null && Convert.ToBoolean(row.Cells["IsActive"].Value) == false)
                                {
                                    // Đặt màu nền của dòng thành xám nếu người dùng bị block
                                    row.DefaultCellStyle.BackColor = Color.LightGray;
                                }
                                else
                                {
                                    // Đặt lại màu nền nếu không bị block
                                    row.DefaultCellStyle.BackColor = Color.White;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddDepartment addDepartment = new FormAddDepartment();
            addDepartment.ShowDialog();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dgvDepartment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a department.");
                return;
            }

            // Lấy DepartmentID từ Tag của dòng được chọn
            string departmentID = dgvDepartment.SelectedRows[0].Tag.ToString();

            // Kết nối cơ sở dữ liệu
            string connectionString = Program.connectionString; // thay bằng chuỗi kết nối của bạn
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string getHeadUserQuery = "SELECT UserID FROM [User] WHERE DepartmentID = @DepartmentID AND IsActive = 1";
                    SqlCommand getHeadCmd = new SqlCommand(getHeadUserQuery, connection);
                    getHeadCmd.Parameters.AddWithValue("@DepartmentID", departmentID);

                    // Lấy UserID của department head
                    object result = getHeadCmd.ExecuteScalar();

                    if (result != null)
                    {
                        string departmentHeadUserID = result.ToString();

                        // Cập nhật trạng thái của department head thành blocked (có thể là Set IsActive = 0 hoặc thêm trường IsBlocked)
                        string blockUserQuery = "UPDATE [User] SET IsActive = 0 WHERE UserID = @UserID";
                        SqlCommand blockUserCmd = new SqlCommand(blockUserQuery, connection);
                        blockUserCmd.Parameters.AddWithValue("@UserID", departmentHeadUserID);

                        int rowsAffected = blockUserCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Department head has been blocked successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to block department head.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No active department head found for the selected department.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    LoadDepartmentData();
                }
            }
        }
        private void btnUnlock_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dgvDepartment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a department.");
                return;
            }

            // Lấy DepartmentID từ Tag của dòng được chọn
            string departmentID = dgvDepartment.SelectedRows[0].Tag.ToString(); // Lấy DepartmentID từ Tag

            // Kết nối cơ sở dữ liệu
            string connectionString = Program.connectionString; // thay bằng chuỗi kết nối của bạn
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Truy vấn để lấy UserID của department head (giả sử department head là user có DepartmentID là departmentID)
                    string getHeadUserQuery = "SELECT UserID FROM [User] WHERE DepartmentID = @DepartmentID AND IsActive = 0"; // Đổi IsActive = 0 để tìm user bị block
                    SqlCommand getHeadCmd = new SqlCommand(getHeadUserQuery, connection);
                    getHeadCmd.Parameters.AddWithValue("@DepartmentID", departmentID);

                    // Lấy UserID của department head
                    object result = getHeadCmd.ExecuteScalar();

                    if (result != null)
                    {
                        string departmentHeadUserID = result.ToString();

                        // Cập nhật trạng thái của department head thành active (IsActive = 1)
                        string unlockUserQuery = "UPDATE [User] SET IsActive = 1 WHERE UserID = @UserID";
                        SqlCommand unlockUserCmd = new SqlCommand(unlockUserQuery, connection);
                        unlockUserCmd.Parameters.AddWithValue("@UserID", departmentHeadUserID);

                        int rowsAffected = unlockUserCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Department head has been unlocked successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to unlock department head.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No blocked department head found for the selected department.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    LoadDepartmentData();
                }
            }
        }


        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadDepartmentData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.ToLower();  // Lấy giá trị tìm kiếm từ textbox

            // Lọc lại dữ liệu trong DataGridView khi có sự thay đổi
            (dgvDepartment.DataSource as DataTable).DefaultView.RowFilter = string.Format(
                "DepartmentName LIKE '%{0}%' OR ManagerName LIKE '%{0}%' OR ManagerEmail LIKE '%{0}%'",
                searchQuery);
        }
    }

}
