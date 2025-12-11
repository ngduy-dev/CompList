using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using FinalProject.Models;

namespace FinalProject.Views
{
    public partial class FormEmployee : Form, ILocalizable
    {
        string connectionString = Program.connectionString;

        public FormEmployee()
        {
            InitializeComponent();
            LoadEmployeeData("All"); // Tải dữ liệu nhân viên
            this.Load += new System.EventHandler(this.Form_Load); // Đăng ký sự kiện Form_Load
            ApplyLanguage();
            dgvEmployee.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void ApplyLanguage()
        {
            lblEmployee.Text = LanguageManager.Translate("employee"); // Tiêu đề
            lblDepartment.Text = LanguageManager.Translate("departments");
            lblSearch.Text = LanguageManager.Translate("search");
            btnReload.Text = LanguageManager.Translate("reload");
            btnAdd.Text = LanguageManager.Translate("add_employee");
            btnDelete.Text = LanguageManager.Translate("delete_employee");
            btnInfomation.Text = LanguageManager.Translate("view_info");

            //if (dgvEmployee.Columns.Count > 0)
            //{
            //    dgvEmployee.Columns["EmployeeID"].HeaderText = LanguageManager.Translate("employee_id");
            //    dgvEmployee.Columns["Name"].HeaderText = LanguageManager.Translate("employee_name");
            //    dgvEmployee.Columns["NumberPhone"].HeaderText = LanguageManager.Translate("phone_number");
            //    dgvEmployee.Columns["DepartmentName"].HeaderText = LanguageManager.Translate("department_name");
            //    dgvEmployee.Columns["Email"].HeaderText = LanguageManager.Translate("email");
            //    dgvEmployee.Columns["Gender"].HeaderText = LanguageManager.Translate("gender");
            //    dgvEmployee.Columns["DateOfBirth"].HeaderText = LanguageManager.Translate("date_of_birth");
            //    dgvEmployee.Columns["IsActive"].HeaderText = LanguageManager.Translate("is_active");
            //}
        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadDepartments(); // Tải phòng ban khi khởi động form
            LoadEmployeeData("All"); // Tải dữ liệu nhân viên
        }

        private void LoadDepartments()
        {
            // Tải danh sách phòng ban vào comboBoxDepartment
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DepartmentID, DepartmentName FROM Department"; // Điều chỉnh nếu tên cột khác
                if (!UserSession.IsDirector)
                {
                    query += " WHERE DepartmentID = @DepartmentID";
                }
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!UserSession.IsDirector)
                    {
                        command.Parameters.AddWithValue("@DepartmentID", UserSession.DepartmentID);
                    }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //comboBoxDepartment.Items.Add(new { Value = "", Text = "All" }); // Thêm giá trị "All"
                        cmbDepartment.Items.Clear();
                        if (UserSession.IsDirector)
                        {
                            cmbDepartment.Items.Add(new { Value = "", Text = "All" }); // Thêm giá trị "All"
                        }
                        while (reader.Read())
                        {
                            cmbDepartment.Items.Add(new
                            {
                                Value = reader["DepartmentID"],
                                Text = reader["DepartmentName"]
                            });
                        }
                    }
                }
            }

            // Thiết lập giá trị hiển thị cho comboBox
            cmbDepartment.DisplayMember = "Text";
            cmbDepartment.ValueMember = "Value";
            if (!UserSession.IsDirector && cmbDepartment.Items.Count > 0)
            {
                cmbDepartment.SelectedIndex = 0; // Chọn phòng ban của nhân viên làm mặc định
            }
        }

        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý thay đổi lựa chọn trong comboBoxDepartment
            string selectedValue = (cmbDepartment.SelectedItem as dynamic)?.Value?.ToString();
            LoadEmployeeData(selectedValue); // Gọi phương thức tải lại dữ liệu nhân viên
        }

        private void LoadEmployeeData(string departmentID = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT 
                           e.EmployeeID, 
                           e.Name, 
                           e.NumberPhone, 
                           d.DepartmentName AS DepartmentName, 
                           e.Email,
                           e.DepartmentID, -- Giữ lại cột này để sử dụng cho việc lọc sau nhưng không hiển thị
                           e.Gender,
                           e.DateOfBirth,
                           e.IsActive
                        FROM 
                           Employee e
                        LEFT JOIN 
                           Department d ON e.DepartmentID = d.DepartmentID";

                //if (!string.IsNullOrEmpty(departmentID) && departmentID != "All")
                //{
                //    query += " WHERE e.DepartmentID = @DepartmentID";
                //}

                // Nếu không phải giám đốc, giới hạn dữ liệu theo phòng ban
                if (!UserSession.IsDirector)
                {
                    if (!string.IsNullOrEmpty(departmentID) && departmentID != "All")
                    {
                        query += " WHERE e.DepartmentID = @DepartmentID AND e.DepartmentID = @UserDepartmentID";
                    }
                    else
                    {
                        query += " WHERE e.DepartmentID = @UserDepartmentID";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(departmentID) && departmentID != "All")
                    {
                        query += " WHERE e.DepartmentID = @DepartmentID";
                    }
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(departmentID) && departmentID != "All")
                    {
                        command.Parameters.AddWithValue("@DepartmentID", departmentID);
                    }
                    // Thêm tham số giới hạn phòng ban cho nhân viên
                    if (!UserSession.IsDirector)
                    {
                        command.Parameters.AddWithValue("@UserDepartmentID", UserSession.DepartmentID);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvEmployee.DataSource = dataTable;

                        // Ẩn cột DepartmentID
                        if (dgvEmployee.Columns.Contains("DepartmentID"))
                        {
                            dgvEmployee.Columns["DepartmentID"].Visible = false;
                        }
                    }
                }

                // Kiểm tra và định dạng giá trị "IsActive"
                foreach (DataGridViewRow row in dgvEmployee.Rows)
                {
                    // Lưu EmployeeID vào Tag
                    row.Tag = row.Cells["EmployeeID"].Value;

                    // Kiểm tra trạng thái IsActive
                    bool isActive = row.Cells["IsActive"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["IsActive"].Value);

                    if (!isActive)
                    {
                        // Đặt màu nền của dòng thành xám nếu IsActive là false
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else
                    {
                        // Đặt màu nền của dòng thành trắng nếu IsActive là true
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            ApplyLanguage();
        }

        private void btnInfomation_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvEmployee.SelectedRows.Count > 0)
            {
                // Lấy employeeID từ hàng được chọn
                string employeeID = dgvEmployee.SelectedRows[0].Cells["EmployeeID"].Value.ToString();

                // Mở form EmployeeInfo với tham số employeeID
                FormEmployeeInfo employeeInfoForm = new FormEmployeeInfo(employeeID);
                employeeInfoForm.Show();
            }
            else
            {
                MessageBox.Show("Please select an employee to view their information.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadEmployeeData("All"); // Tải lại dữ liệu nhân viên
            cmbDepartment.SelectedIndex = cmbDepartment.FindStringExact("All");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult result1 = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Kiểm tra xem có hàng nào được chọn trong DataGridView hay không
            if (dgvEmployee.SelectedRows.Count > 0 && result1 == DialogResult.Yes)
            {
                // Lấy EmployeeID từ hàng được chọn
                string employeeID = dgvEmployee.SelectedRows[0].Cells["EmployeeID"].Value.ToString();

                try
                {
                    using (SqlConnection connection = new SqlConnection(Program.connectionString))
                    {
                        connection.Open();

                        // Kiểm tra xem nhân viên có có liên kết với bất kỳ checklist item nào không
                        string checkQuery = "SELECT COUNT(*) FROM ChecklistItem WHERE EmployeeID = @EmployeeID";
                        SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                        checkCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                        int itemCount = (int)checkCommand.ExecuteScalar();

                        if (itemCount > 0)
                        {
                            // Nếu có các checklist items, hỏi người dùng xem có muốn xóa chúng không
                            DialogResult result = MessageBox.Show(
                                "This employee has existing checklist items. Do you want to delete them as well?",
                                "Confirm Delete Checklist Items",
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Warning);

                            if (result == DialogResult.Yes)
                            {
                                // Xóa tất cả checklist items của nhân viên
                                string deleteChecklistQuery = "DELETE FROM ChecklistItem WHERE EmployeeID = @EmployeeID";
                                SqlCommand deleteChecklistCommand = new SqlCommand(deleteChecklistQuery, connection);
                                deleteChecklistCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                                deleteChecklistCommand.ExecuteNonQuery();
                                MessageBox.Show("All checklist items have been deleted.");
                            }
                            else if (result == DialogResult.No)
                            {
                                MessageBox.Show("The checklist items are not deleted.");
                                return;
                            }
                            else
                            {
                                // Nếu người dùng chọn Cancel
                                MessageBox.Show("No changes have been made.");
                                return;
                            }
                        }

                        // Tiến hành xóa nhân viên nếu không có lỗi
                        string query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@EmployeeID", employeeID);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Employee deleted successfully.");

                                // Tải lại dữ liệu sau khi xóa
                                LoadEmployeeData("All");
                                cmbDepartment.SelectedIndex = cmbDepartment.FindStringExact("All");
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete the employee.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    MessageBox.Show("An error occurred while deleting the employee: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Lấy employeeID từ hàng được chọn
            string employeeID = GenerateEmployeeID(); // Tạo employeeID mới

            // Mở form AddEmployee và truyền employeeID
            FormAddEmployee addEmployeeForm = new FormAddEmployee(employeeID);
            addEmployeeForm.Show();
        }
        private string GenerateEmployeeID()
        {
            string newEmployeeID = string.Empty;

            // Kết nối tới cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                // Lấy EmployeeID lớn nhất hiện có
                string query = "SELECT MAX(CAST(SUBSTRING(EmployeeID, 4, LEN(EmployeeID) - 3) AS INT)) FROM Employee";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();

                    // Nếu không có nhân viên nào, đặt ID là 'EMP001'
                    int maxId = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    newEmployeeID = "EMP" + (maxId + 1).ToString("D3"); // Định dạng ID mới là 'EMP' + số từ 001 trở đi
                }
            }

            return newEmployeeID;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower(); // Lấy giá trị tìm kiếm và chuyển thành chữ thường

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadEmployeeData("All"); // Nếu không có từ khóa tìm kiếm, tải lại tất cả nhân viên
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // Truy vấn cơ bản với alias rõ ràng
                        string query = @"
                    SELECT 
                        e.EmployeeID, 
                        e.Name, 
                        e.NumberPhone, 
                        e.Email, 
                        e.DepartmentID, 
                        d.DepartmentName 
                    FROM 
                        Employee e
                    LEFT JOIN 
                        Department d ON e.DepartmentID = d.DepartmentID
                    WHERE 
                        (e.Name LIKE @searchTerm OR 
                         e.Email LIKE @searchTerm OR 
                         e.NumberPhone LIKE @searchTerm OR 
                         e.EmployeeID LIKE @searchTerm)";

                        // Nếu không phải giám đốc, thêm điều kiện lọc theo phòng ban
                        if (!UserSession.IsDirector)
                        {
                            query += " AND e.DepartmentID = @UserDepartmentID";
                        }

                        SqlCommand command = new SqlCommand(query, conn);
                        command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                        if (!UserSession.IsDirector)
                        {
                            command.Parameters.AddWithValue("@UserDepartmentID", UserSession.DepartmentID);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvEmployee.DataSource = dt; // Gán kết quả tìm kiếm vào DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error during search: " + ex.Message);
                    }
                }
            }
        }


        private void dataGridViewEmployee_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvEmployee.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader)
            {
                ContextMenu menu = new ContextMenu();
                foreach (DataGridViewColumn column in dgvEmployee.Columns)
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
                menu.Show(dgvEmployee, e.Location);
            }
        }
    }
}
