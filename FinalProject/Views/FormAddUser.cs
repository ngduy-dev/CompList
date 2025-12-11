using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using FinalProject.Models;

namespace FinalProject.Views
{
    public partial class FormAddUser : Form, ILocalizable
    {
        public FormAddUser()
        {
            InitializeComponent();
            LoadDepartments();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            lblInfomation.Text = LanguageManager.Translate("newuser");
            lblEmployeeName.Text = LanguageManager.Translate("departments");
            lblUser.Text = LanguageManager.Translate("detailinfor");
            lblUserID.Text = LanguageManager.Translate("user_id");
            lblPhoneNumber.Text = LanguageManager.Translate("phone_number");
            lblBirthday.Text = LanguageManager.Translate("date_of_birth");
            lblEmail.Text = LanguageManager.Translate("email");
            lblFullName.Text = LanguageManager.Translate("full_name");
            lblGender.Text = LanguageManager.Translate("gender");
            btnClose.Text = LanguageManager.Translate("close");
            btnSave.Text = LanguageManager.Translate("save");
        }
        private void LoadDepartments()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    string query = "SELECT DepartmentID, DepartmentName FROM Department";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable departmentTable = new DataTable();
                            adapter.Fill(departmentTable);

                            // Gán DataSource cho ComboBox
                            cmbDepartment.DataSource = departmentTable;
                            cmbDepartment.DisplayMember = "DepartmentName"; // Hiển thị tên phòng
                            cmbDepartment.ValueMember = "DepartmentID"; // Lưu mã phòng
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateUserID()
        {
            if (cmbDepartment.SelectedValue == null)
            {
                MessageBox.Show("Please select a department!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    // Lấy 4 chữ đầu tiên từ tên phòng
                    string departmentName = cmbDepartment.Text;
                    string prefix = departmentName.Length >= 4 ? departmentName.Substring(0, 4).ToUpper() : departmentName.ToUpper();

                    // Truy vấn để lấy danh sách UserID có cùng tiền tố
                    string query = "SELECT UserID FROM [User] WHERE UserID LIKE @Prefix + '%'";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Prefix", prefix);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<int> existingNumbers = new List<int>();

                            while (reader.Read())
                            {
                                string userId = reader["UserID"].ToString();
                                if (userId.Length > prefix.Length)
                                {
                                    // Lấy phần số từ UserID
                                    string numberPart = userId.Substring(prefix.Length);
                                    if (int.TryParse(numberPart, out int number))
                                    {
                                        existingNumbers.Add(number);
                                    }
                                }
                            }

                            // Xác định số tiếp theo chưa tồn tại
                            int newNumber = 1;
                            while (existingNumbers.Contains(newNumber))
                            {
                                newNumber++;
                            }

                            // Ghép tiền tố với số
                            return $"{prefix}{newNumber:D3}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating UserID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string generatedUserID = GenerateUserID();
            if (!string.IsNullOrEmpty(generatedUserID))
            {
                txtUserID.Text = generatedUserID;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                cboGender.SelectedIndex == -1 ||
                dtpBirthDay.Value == null)
            {
                MessageBox.Show("Please fill all the required fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    string userID = txtUserID.Text;
                    string fullName = txtFullName.Text.Trim();
                    string email = txtEmail.Text;
                    string phoneNumber = txtPhoneNumber.Text;
                    string gender = cboGender.SelectedItem.ToString();
                    DateTime dateOfBirth = dtpBirthDay.Value;
                    string password = "Pass1234";

                    DateTime? lastLogin = null;
                    bool isActive = true;

                    // Kiểm tra email đã tồn tại trong cơ sở dữ liệu hay chưa
                    string checkEmailQuery = "SELECT COUNT(*) FROM [User] WHERE Email = @Email";
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

                    // Kiểm tra số điện thoại đã tồn tại trong cơ sở dữ liệu hay chưa
                    string checkPhoneQuery = "SELECT COUNT(*) FROM [User] WHERE PhoneNumber = @PhoneNumber";
                    using (SqlCommand checkPhoneCmd = new SqlCommand(checkPhoneQuery, connection))
                    {
                        checkPhoneCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        int phoneCount = (int)checkPhoneCmd.ExecuteScalar();

                        if (phoneCount > 0)
                        {
                            MessageBox.Show("This phone number is already registered. Please use a different phone number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    int age = DateTime.Now.Year - dateOfBirth.Year;
                    if (dateOfBirth > DateTime.Now.AddYears(-age)) age--;

                    if (age < 18)
                    {
                        MessageBox.Show("User must be at least 18 years old.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (System.Text.RegularExpressions.Regex.IsMatch(fullName, @"[^a-zA-Z\s]"))
                    {
                        MessageBox.Show("Name cannot contain special characters or numbers.");
                        return;
                    }

                    if (!Regex.IsMatch(phoneNumber, @"^\d{10}$"))
                    {
                        MessageBox.Show("Invalid phone number. It must contain 10 digits.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                    {
                        MessageBox.Show("Invalid email format.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string departmentID = cmbDepartment.SelectedValue.ToString();

                    string query = @"
            INSERT INTO [User] 
            (UserID, Username, Password, FullName, Email, PhoneNumber, LastLogin, IsActive, Gender, DateOfBirth, DepartmentID) 
            VALUES 
            (@UserID, @Username, @Password, @FullName, @Email, @PhoneNumber, @LastLogin, @IsActive, @Gender, @DateOfBirth, @DepartmentID)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@Username", txtUserID.Text);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@LastLogin", lastLogin.HasValue ? (object)lastLogin : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IsActive", isActive);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        cmd.Parameters.AddWithValue("@DepartmentID", departmentID);

                        cmd.ExecuteNonQuery();
                    }

                    SendEmailToUser(email, userID, password);
                }
                MessageBox.Show("User saved successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SendEmailToUser(string email, string userid, string password)
        {
            try
            {
                // Cấu hình SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")  // Thay thế bằng SMTP server bạn sử dụng
                {
                    Port = 587,  // Cổng SMTP thường dùng là 587
                    Credentials = new NetworkCredential("cnpmquatrinh2@gmail.com", "eqyr zjud dbgn hbik"),  // Thông tin xác thực tài khoản email
                    EnableSsl = true  // Bật mã hóa SSL
                };

                // Soạn thảo email
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("cnpmquatrinh2@gmail.com"),  // Địa chỉ email gửi
                    Subject = "Thông tin tài khoản của bạn",
                    Body = $"Chào bạn,\n\nĐây là thông tin tài khoản của bạn:\n\n" +
                            $"UserID: {userid}\n" +
                            $"Password: {password}\n\n" +
                            "Trân trọng,\nBan quản trị hệ thống.",
                    IsBodyHtml = false  // Nội dung email không phải là HTML
                };

                // Thêm người nhận email
                mailMessage.To.Add(email);

                // Gửi email
                smtpClient.Send(mailMessage);

                MessageBox.Show("The email has been sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");

            }
        }
    }
}