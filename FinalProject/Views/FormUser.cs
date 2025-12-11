using FinalProject.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalProject.Views
{
    public partial class FormUser : Form, ILocalizable
    {
        private string connectionString = Program.connectionString;

        public FormUser()
        {
            InitializeComponent();
            LoadUsers(); // Tải người dùng ban đầu khi form được mở
            ApplyLanguage();
            dgvUser.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void ApplyLanguage()
        {
            lblLogoUser.Text = LanguageManager.Translate("user");
            lblSearch.Text = LanguageManager.Translate("search");
            btnReload.Text = LanguageManager.Translate("reload");
            btnAdd.Text = LanguageManager.Translate("add_user");
            btnBlock.Text = LanguageManager.Translate("block_user");
            btnUnblock.Text = LanguageManager.Translate("unblock_user");

            //if (dgvUser.Columns.Count > 0)
            //{
            //    dgvUser.Columns["UserID"].HeaderText = LanguageManager.Translate("user_id");
            //    dgvUser.Columns["FullName"].HeaderText = LanguageManager.Translate("full_name");
            //    dgvUser.Columns["Email"].HeaderText = LanguageManager.Translate("email");
            //    dgvUser.Columns["PhoneNumber"].HeaderText = LanguageManager.Translate("phone_number");
            //    dgvUser.Columns["Gender"].HeaderText = LanguageManager.Translate("gender");
            //    dgvUser.Columns["DateOfBirth"].HeaderText = LanguageManager.Translate("date_of_birth");
            //    dgvUser.Columns["IsActive"].HeaderText = LanguageManager.Translate("is_active");
            //}
        }

        private void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT UserID, FullName, Email, PhoneNumber,Gender, DateOfBirth, IsActive FROM [User]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvUser.DataSource = dt; // Gán DataTable vào DataGridView
                    ApplyLanguage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        // Xử lý khi người dùng nhập vào TextBox tìm kiếm
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower(); // Lấy giá trị tìm kiếm và chuyển thành chữ thường
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadUsers(); // Nếu không có từ khóa tìm kiếm, tải lại tất cả người dùng
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        // Sử dụng LIKE để tìm kiếm theo từ khóa trong các trường: Username, FullName, Email, PhoneNumber
                        string query = "SELECT  UserID, FullName, Email, PhoneNumber, Gender, DateOfBirth, IsActive " +
                                       "FROM [User] " +
                                       "WHERE FullName LIKE @searchTerm OR Email LIKE @searchTerm OR PhoneNumber LIKE @searchTerm OR UserID LIKE @searchTerm";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                        adapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvUser.DataSource = dt; // Gán kết quả tìm kiếm vào DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error during search: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridViewUser_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvUser.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader)
            {
                ContextMenu menu = new ContextMenu();
                foreach (DataGridViewColumn column in dgvUser.Columns)
                {
                    MenuItem item = new MenuItem(column.HeaderText);
                    item.Checked = column.Visible;
                    item.Click += (s, a) =>
                    {
                        column.Visible = !column.Visible;
                        item.Checked = column.Visible;
                    };
                    menu.MenuItems.Add(item);
                }
                menu.Show(dgvUser, e.Location);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count > 0)
            {
                // Lấy UserID của người dùng được chọn
                string userId = dgvUser.SelectedRows[0].Cells["UserID"].Value.ToString();
                int isActive = Convert.ToInt32(dgvUser.SelectedRows[0].Cells["IsActive"].Value);

                // Kiểm tra nếu người dùng đã được mở khóa
                if (isActive == 0)
                {
                    MessageBox.Show("This user is already block.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE [User] SET IsActive = 0 WHERE UserID = @UserID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User has been blocked successfully.");
                            LoadUsers(); // Tải lại danh sách người dùng sau khi cập nhật
                        }
                        else
                        {
                            MessageBox.Show("Failed to block the user. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while blocking the user: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to block.");
            }
        }


        private void btnUnblock_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count > 0)
            {
                // Lấy UserID của người dùng được chọn
                string userId = dgvUser.SelectedRows[0].Cells["UserID"].Value.ToString();
                int isActive = Convert.ToInt32(dgvUser.SelectedRows[0].Cells["IsActive"].Value);

                // Kiểm tra nếu người dùng đã được mở khóa
                if (isActive == 1)
                {
                    MessageBox.Show("This user is already active.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE [User] SET IsActive = 1 WHERE UserID = @UserID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User has been unblocked successfully.");
                            LoadUsers(); // Tải lại danh sách người dùng sau khi cập nhật
                        }
                        else
                        {
                            MessageBox.Show("Failed to unblock the user. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while unblocking the user: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to unblock.");
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            FormAddUser addUser = new FormAddUser();
            addUser.ShowDialog();
        }
    }
}
