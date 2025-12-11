using FinalProject.Models;
using FluentEmail.Core;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static QRCoder.PayloadGenerator;

namespace FinalProject.Views
{
    public partial class FormEmployeeInfo : Form, ILocalizable
    {
        private string employeeID;

        public FormEmployeeInfo(string employeeID)
        {
            InitializeComponent();
            this.employeeID = employeeID;

            // Hiển thị employeeID trên lblInfomation
            lblInfomation.Text = $"Information of EmployeeID: {employeeID}";

            // Tải dữ liệu của nhân viên
            LoadEmployeeData();

            // Tải danh sách công việc của nhân viên
            LoadEmployeeChecklistItems();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            lblInfomation.Text = $"{LanguageManager.Translate("employee_information")} {employeeID}";
            lblEmployeeName.Text = LanguageManager.Translate("employee_name");
            lblNumberPhone.Text = LanguageManager.Translate("phone_number");
            lblEmail.Text = LanguageManager.Translate("email");
            lblDepartment.Text = LanguageManager.Translate("departments");
            lblIsActive.Text = LanguageManager.Translate("status");
            btnSave.Text = LanguageManager.Translate("save");
            btnClose.Text = LanguageManager.Translate("close");

            // Cập nhật DataGridView
            if (dtghecklistItem.Columns.Count > 0)
            {
                dtghecklistItem.Columns["ItemID"].HeaderText = LanguageManager.Translate("checklist_item_id");
                dtghecklistItem.Columns["TaskDescription"].HeaderText = LanguageManager.Translate("task_description");
                dtghecklistItem.Columns["IsCompleted"].HeaderText = LanguageManager.Translate("status");
                dtghecklistItem.Columns["DueDate"].HeaderText = LanguageManager.Translate("due_date");
            }
        }

        private void LoadEmployeeData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT Name, NumberPhone, Email, DepartmentID, IsActive
                         FROM Employee 
                         WHERE EmployeeID = @EmployeeID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Gán dữ liệu vào các TextBox
                                txtName.Text = reader["Name"].ToString();
                                txtNumberPhone.Text = reader["NumberPhone"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                cbxIsActive.SelectedItem = reader["IsActive"].ToString();
                                // Lấy DepartmentID để tìm tên phòng ban và chọn
                                string departmentID = reader["DepartmentID"].ToString();
                                LoadDepartments(departmentID);
                            }
                            else
                            {
                                MessageBox.Show("Employee information not found with ID: " + employeeID);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during search: " + ex.Message);
            }
        }

        private void LoadEmployeeChecklistItems()
        {
            try
            {
                // Truy vấn các checklist item cho nhân viên từ bảng ChecklistItem
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT ItemID, TaskDescription, IsCompleted, DueDate
                         FROM ChecklistItem 
                         WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", this.employeeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Đảm bảo dataGridViewChecklistItem đã được thiết lập với các cột cần thiết
                            DataTable dt = new DataTable();
                            dt.Columns.Add("ItemID");
                            dt.Columns.Add("TaskDescription");
                            dt.Columns.Add("IsCompleted");
                            dt.Columns.Add("DueDate");

                            while (reader.Read())
                            {
                                DataRow row = dt.NewRow();

                                // Kiểm tra và gán giá trị từng cột
                                row["ItemID"] = reader["ItemID"] != DBNull.Value ? reader["ItemID"].ToString() : "N/A";
                                row["TaskDescription"] = reader["TaskDescription"] != DBNull.Value ? reader["TaskDescription"].ToString() : "No Description";
                                row["IsCompleted"] = reader["IsCompleted"] != DBNull.Value && Convert.ToBoolean(reader["IsCompleted"]) ? "Completed" : "Pending";
                                row["DueDate"] = reader["DueDate"] != DBNull.Value ? Convert.ToDateTime(reader["DueDate"]).ToString("dd/MM/yyyy") : "No Due Date";

                                dt.Rows.Add(row);
                            }

                            // Gán DataTable vào DataGridView
                            dtghecklistItem.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during search: " + ex.Message);
            }
        }


        private void LoadDepartments(string selectedDepartmentID)
        {
            string selectedDepartmentName = string.Empty;
            try
            {
                // Tải danh sách phòng ban vào comboBoxDepartment
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();
                    string query = "SELECT DepartmentID, DepartmentName FROM Department";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var departmentName = reader["DepartmentName"].ToString();
                                var departmentID = reader["DepartmentID"].ToString();

                                // Kiểm tra nếu phòng ban khớp với DepartmentID, lưu lại tên phòng ban
                                if (departmentID == selectedDepartmentID)
                                {
                                    selectedDepartmentName = departmentName;
                                }

                                // Thêm phòng ban vào ComboBox
                                cmbDepartment.Items.Add(new
                                {
                                    Value = departmentID,
                                    Text = departmentName
                                });
                            }
                        }
                    }
                }

                // Thiết lập giá trị hiển thị và chọn phòng ban hiện tại
                cmbDepartment.DisplayMember = "Text";
                cmbDepartment.ValueMember = "Value";

                // Chọn phòng ban theo tên
                foreach (var item in cmbDepartment.Items)
                {
                    if ((item as dynamic).Text == selectedDepartmentName)
                    {
                        cmbDepartment.SelectedItem = item;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during search: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currentName = txtName.Text;
            string currentNumberPhone = txtNumberPhone.Text;
            string currentEmail = txtEmail.Text;
            string currentDepartmentID = (cmbDepartment.SelectedItem as dynamic)?.Value.ToString();
            bool currentIsActive = cbxIsActive.SelectedItem != null && cbxIsActive.SelectedItem.ToString() == "True"; // Giả sử ComboBox chứa "True" hoặc "False"

            // Kiểm tra tên
            if (string.IsNullOrWhiteSpace(currentName))
            {
                MessageBox.Show("Name cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ký tự đặc biệt
            if (System.Text.RegularExpressions.Regex.IsMatch(currentName, @"[^a-zA-Z\s]"))
            {
                MessageBox.Show("Name cannot contain special characters or numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số điện thoại (giả sử số điện thoại có 10 chữ số)
            if (!Regex.IsMatch(currentNumberPhone, @"^\d{10}$"))
            {
                MessageBox.Show("Invalid phone number. It must contain 10 digits.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra email
            if (!Regex.IsMatch(currentEmail, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                MessageBox.Show("Invalid email format.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool hasChanges = false;

            try
            {
                // Open connection to check current data from the database
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    // Get current data from database
                    string query = @"SELECT Name, NumberPhone, Email, DepartmentID, IsActive 
                         FROM Employee 
                         WHERE EmployeeID = @EmployeeID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", this.employeeID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (currentName != reader["Name"].ToString()) hasChanges = true;
                                if (currentNumberPhone != reader["NumberPhone"].ToString()) hasChanges = true;
                                if (currentEmail != reader["Email"].ToString()) hasChanges = true;
                                if (reader["DepartmentID"].ToString() != currentDepartmentID)
                                {
                                    hasChanges = true;
                                    // Kiểm tra xem nhân viên này có checklist hay không
                                    using (SqlConnection conn = new SqlConnection(Program.connectionString))
                                    {
                                        conn.Open();

                                        string queryCheck = "SELECT COUNT(*) FROM [ChecklistItem] WHERE EmployeeID = @EmployeeID";
                                        SqlCommand cmdCheck = new SqlCommand(queryCheck, conn);
                                        cmdCheck.Parameters.AddWithValue("@EmployeeID", employeeID);

                                        int checklistCount = (int)cmdCheck.ExecuteScalar();

                                        if (checklistCount > 0)
                                        {
                                            // Hiển thị thông báo nếu có checklist
                                            DialogResult result = MessageBox.Show(
                                                "This employee has existing checklists. Do you want to update or delete them?",
                                                "Checklist Update",
                                                MessageBoxButtons.YesNoCancel,
                                                MessageBoxIcon.Warning
                                            );

                                            if (result == DialogResult.Yes)
                                            {
                                                // Update Checklist: Thay đổi thông tin liên quan
                                                string queryUpdateChecklist = @"
                                                UPDATE [ChecklistItem]
                                                SET EmployeeID = NULL -- Hoặc gán giá trị khác phù hợp
                                                WHERE EmployeeID = @EmployeeID";
                                                SqlCommand cmdUpdateChecklist = new SqlCommand(queryUpdateChecklist, conn);
                                                cmdUpdateChecklist.Parameters.AddWithValue("@EmployeeID", employeeID);
                                                cmdUpdateChecklist.ExecuteNonQuery();
                                                MessageBox.Show("All checklists have been updated.");
                                            }
                                            else if (result == DialogResult.No)
                                            {
                                                string queryDeleteChecklist = "DELETE FROM [ChecklistItem] WHERE EmployeeID = @EmployeeID";
                                                SqlCommand cmdDeleteChecklist = new SqlCommand(queryDeleteChecklist, conn);
                                                cmdDeleteChecklist.Parameters.AddWithValue("@EmployeeID", employeeID);
                                                cmdDeleteChecklist.ExecuteNonQuery();
                                                MessageBox.Show("All checklists have been deleted.");
                                            }
                                            else
                                            {
                                                // Cancel action
                                                MessageBox.Show("No changes have been made.");
                                                return;
                                            }
                                        }
                                    }
                                }
                                if (currentIsActive != Convert.ToBoolean(reader["IsActive"])) hasChanges = true;
                            }
                        }
                    }

                    // If there are changes, update the database
                    if (hasChanges)
                    {
                        string updateQuery = @"UPDATE Employee SET 
                                   Name = @Name, 
                                   NumberPhone = @NumberPhone, 
                                   Email = @Email, 
                                   DepartmentID = @DepartmentID, 
                                   IsActive = @IsActive 
                                   WHERE EmployeeID = @EmployeeID";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Name", currentName);
                            updateCommand.Parameters.AddWithValue("@NumberPhone", currentNumberPhone);
                            updateCommand.Parameters.AddWithValue("@Email", currentEmail);
                            updateCommand.Parameters.AddWithValue("@DepartmentID", currentDepartmentID);
                            updateCommand.Parameters.AddWithValue("@IsActive", currentIsActive);
                            updateCommand.Parameters.AddWithValue("@EmployeeID", this.employeeID);

                            int rowsAffected = updateCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data has been successfully updated.");
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("No changes were made.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No changes to update.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during search: " + ex.Message);
            }
        }
    } 
}
