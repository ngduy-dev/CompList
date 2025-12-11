using FinalProject.Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FinalProject.Views
{
    public partial class FormAddEmployee : Form, ILocalizable
    {
        private string employeeID;

        public FormAddEmployee(string employeeID)
        {
            InitializeComponent();
            LoadDepartments(); // Tải danh sách phòng ban khi khởi động form
            this.employeeID = employeeID;  // Lưu employeeID để sử dụng sau này
            lblInfomation.Text = "New Employee ID: " + this.employeeID;
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            lblInfomation.Text = LanguageManager.Translate("newem");
            lblEmployeeName.Text = LanguageManager.Translate("employee_name");
            lblNumberPhone.Text = LanguageManager.Translate("phone_number");
            lblDepartment.Text = LanguageManager.Translate("departments");
            lblBirthday.Text = LanguageManager.Translate("date_of_birth");
            lblEmail.Text = LanguageManager.Translate("email");
            lblGender.Text = LanguageManager.Translate("gender");
            btnClose.Text = LanguageManager.Translate("btnclose");
            btnSave.Text = LanguageManager.Translate("btnsave");
        }

        // Hàm để load danh sách phòng ban vào comboBox
        // Hàm để load danh sách phòng ban vào comboBox
        private void LoadDepartments()
        {
            cmbDepartment.Items.Clear();  // Xóa các mục cũ trong ComboBox
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
                            // Thêm phòng ban vào ComboBox dưới dạng KeyValuePair<string, string>
                            cmbDepartment.Items.Add(new KeyValuePair<string, string>(
                                reader["DepartmentID"].ToString(),  // Sử dụng kiểu string cho DepartmentID
                                reader["DepartmentName"].ToString()));
                        }
                    }
                }
            }

            // Thiết lập giá trị hiển thị cho comboBox
            cmbDepartment.DisplayMember = "Value";  // Hiển thị tên phòng ban
            cmbDepartment.ValueMember = "Key";      // Lưu trữ DepartmentID dưới dạng string
        }


        // Xử lý khi người dùng nhấn nút Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtNumberPhone.Text;
            string email = txtEmail.Text;
            string departmentID = ((KeyValuePair<string, string>)cmbDepartment.SelectedItem).Key;
            string gender = cmbGender.SelectedItem?.ToString();
            DateTime dateOfBirth = dtpBirthDay.Value;

            // Tính tuổi
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Now.AddYears(-age)) age--;

            if (age < 18)
            {
                MessageBox.Show("User must be at least 18 years old.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tên
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số điện thoại (giả sử số điện thoại có 10 chữ số)
            if (!Regex.IsMatch(phone, @"^\d{10}$"))
            {
                MessageBox.Show("Invalid phone number. It must contain 10 digits.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra email
            if (!Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                MessageBox.Show("Invalid email format.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra các trường dữ liệu không bị trống
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Please fill in all input.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    // Kiểm tra email đã tồn tại
                    string checkEmailQuery = "SELECT COUNT(*) FROM Employee WHERE Email = @Email";
                    using (SqlCommand checkEmailCmd = new SqlCommand(checkEmailQuery, connection))
                    {
                        checkEmailCmd.Parameters.AddWithValue("@Email", email);
                        int emailCount = (int)checkEmailCmd.ExecuteScalar();

                        if (emailCount > 0)
                        {
                            MessageBox.Show("This email is already registered. Please use a different email.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Kiểm tra số điện thoại đã tồn tại
                    string checkPhoneQuery = "SELECT COUNT(*) FROM Employee WHERE NumberPhone = @NumberPhone";
                    using (SqlCommand checkPhoneCmd = new SqlCommand(checkPhoneQuery, connection))
                    {
                        checkPhoneCmd.Parameters.AddWithValue("@NumberPhone", phone);
                        int phoneCount = (int)checkPhoneCmd.ExecuteScalar();

                        if (phoneCount > 0)
                        {
                            MessageBox.Show("This phone number is already registered. Please use a different phone number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Thêm nhân viên vào cơ sở dữ liệu
                    string query = @"INSERT INTO Employee (EmployeeID, Name, NumberPhone, Email, DepartmentID, Gender, DateOfBirth) 
                             VALUES (@EmployeeID, @Name, @NumberPhone, @Email, @DepartmentID, @Gender, @DateOfBirth)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", this.employeeID);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@NumberPhone", phone);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@DepartmentID", departmentID);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("The employee has been successfully added.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Đóng form sau khi lưu thành công
                        }
                        else
                        {
                            MessageBox.Show("Error adding employee.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Xử lý khi người dùng nhấn nút Close
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
