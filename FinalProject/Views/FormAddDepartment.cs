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
using FinalProject.Models;

namespace FinalProject.Views
{
    public partial class FormAddDepartment : Form, ILocalizable
    {
        public FormAddDepartment()
        {
            InitializeComponent();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            lblInfomation.Text = LanguageManager.Translate("newdep");
            lblEmployeeName.Text = LanguageManager.Translate("depname");
            lblUser.Text = LanguageManager.Translate("newaccfordep");
            lblUserID.Text = LanguageManager.Translate("user_id");
            lblPhoneNumber.Text = LanguageManager.Translate("phone_number");
            lblBirthday.Text = LanguageManager.Translate("date_of_birth");
            lblEmail.Text = LanguageManager.Translate("email");
            lblFullName.Text = LanguageManager.Translate("full_name");
            lblGender.Text = LanguageManager.Translate("gender");
            btnClose.Text = LanguageManager.Translate("btnclose");
            btnSave.Text = LanguageManager.Translate("btnsave");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string departmentName = txtDepartmentName.Text.Trim();
            string userID = txtUserID.Text;
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string gender = cmbGender.SelectedItem?.ToString(); // Lấy giá trị từ ComboBox Gender
            DateTime dateOfBirth = dtpBirthDay.Value; // Lấy giá trị từ DateTimePicker

            // Tính tuổi
            int age = DateTime.Now.Year - dateOfBirth.Year;

            // Kiểm tra nếu ngày sinh chưa tới trong năm hiện tại, giảm tuổi đi 1
            if (dateOfBirth > DateTime.Now.AddYears(-age))
            {
                age--;
            }

            // Kiểm tra tuổi đủ 18 hay chưa
            if (age < 18)
            {
                MessageBox.Show("User must be at least 18 years old.");
                return;
            }


            // Kiểm tra tên
            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }

            // Kiểm tra ký tự đặc biệt
            if (System.Text.RegularExpressions.Regex.IsMatch(fullName, @"[^a-zA-Z\s]"))
            {
                MessageBox.Show("Name cannot contain special characters or numbers.");
                return;
            }

            // Kiểm tra số điện thoại (giả sử số điện thoại có 10 chữ số)
            if (!Regex.IsMatch(phoneNumber, @"^\d{10}$"))
            {
                MessageBox.Show("Invalid phone number. It must contain 10 digits.");
                return;
            }

            // Kiểm tra email
            if (!Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            // Kiểm tra nếu tên phòng ban và thông tin người dùng không rỗng
            if (string.IsNullOrEmpty(departmentName) || string.IsNullOrEmpty(userID) ||
                string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Kiểm tra tính hợp lệ của UserID (Độ dài tối thiểu là 4 ký tự)
            if (userID.Length < 4)
            {
                MessageBox.Show("UserID must be at least 4 characters long.");
                return;
            }

            // Kiểm tra tính hợp lệ của email
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            // Kiểm tra tính hợp lệ của Password (Độ dài tối thiểu 6 ký tự, có ít nhất một chữ cái và một số)
            string password = "Pass1234"; // Mật khẩu mặc định
            if (!IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 6 characters long and contain at least one letter and one number.");
                return;
            }

            string connectionString = Program.connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string departmentPrefix = departmentName.Length >= 4 ? departmentName.Substring(0, 4).ToUpper() : departmentName.ToUpper();

                    // Kiểm tra xem prefix có tồn tại trong CSDL không
                    string checkPrefixExistsQuery = @"
        SELECT CASE WHEN EXISTS (
            SELECT 1
            FROM Department
            WHERE DepartmentID LIKE @prefix + '%'
        ) THEN 1 ELSE 0 END";

                    SqlCommand checkPrefixCmd = new SqlCommand(checkPrefixExistsQuery, connection);
                    checkPrefixCmd.Parameters.AddWithValue("@prefix", departmentPrefix);
                    bool prefixExists = (int)checkPrefixCmd.ExecuteScalar() == 1; // Chuyển kết quả thành kiểu bool

                    string newDepartmentID = null;

                    if (!prefixExists)  // Nếu chưa có mã phòng nào với prefix
                    {
                        // Tạo mã phòng chỉ với prefix
                        newDepartmentID = departmentPrefix;
                    }
                    else
                    {
                        // Nếu đã có mã phòng với prefix, tìm số lớn nhất và tăng thêm
                        string getMaxDepartmentIDQuery = @"
                        SELECT ISNULL(MAX(CAST(SUBSTRING(DepartmentID, 5, LEN(DepartmentID) - 4) AS INT)), 0)
                        FROM Department
                        WHERE DepartmentID LIKE @prefix + '%'";
                        SqlCommand getMaxCmd = new SqlCommand(getMaxDepartmentIDQuery, connection);
                        getMaxCmd.Parameters.AddWithValue("@prefix", departmentPrefix);
                        int maxNumber = (int)getMaxCmd.ExecuteScalar();

                        // Tăng số lên để tạo mã phòng mới
                        int newDepartmentNumber = maxNumber + 1;

                        // Tạo DepartmentID mới (dạng prefix + số kế tiếp)
                        if (newDepartmentNumber == 1)
                        {
                            newDepartmentID = departmentPrefix; // Nếu là lần đầu tiên, chỉ có prefix
                        }
                        else
                        {
                            newDepartmentID = departmentPrefix + (newDepartmentNumber - 1).ToString(); // Thêm số vào sau prefix
                        }

                        // Kiểm tra lại prefix khi đã tăng
                        checkPrefixCmd.Parameters.Clear();
                        checkPrefixCmd.Parameters.AddWithValue("@prefix", departmentPrefix);
                        prefixExists = (int)checkPrefixCmd.ExecuteScalar() == 1;  // Cập nhật lại check

                        // Nếu xảy ra lỗi, cắt bớt ký tự cuối trong prefix và kiểm tra lại
                        while (prefixExists && departmentPrefix.Length > 1)
                        {
                            if (departmentPrefix.Length == 4)
                            {
                                departmentPrefix = departmentPrefix.Substring(0, departmentPrefix.Length - 1);
                            } 
                            newDepartmentID = departmentPrefix + (newDepartmentNumber + 1).ToString();

                            newDepartmentNumber += 1;
                            checkPrefixCmd.Parameters.Clear();
                            checkPrefixCmd.Parameters.AddWithValue("@prefix", newDepartmentID);
                            prefixExists = (int)checkPrefixCmd.ExecuteScalar() == 1; // Kiểm tra lại
                        }
                    }

                    // Thêm phòng ban mới với DepartmentID tự động tăng
                    string insertDepartmentQuery = "INSERT INTO Department (DepartmentName, DepartmentID) VALUES (@DepartmentName, @DepartmentID)";
                    using (SqlCommand cmd = new SqlCommand(insertDepartmentQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                        cmd.Parameters.AddWithValue("@DepartmentID", newDepartmentID);
                        cmd.ExecuteNonQuery(); // Thực thi câu lệnh INSERT phòng ban

                        // Thêm người dùng mới và gán DepartmentID
                        string insertUserQuery = "INSERT INTO [User] (UserID, Username, Password, FullName, Gender, DateOfBirth, Email, PhoneNumber, IsActive, DepartmentID) " +
                                                "VALUES (@UserID, @Username, @Password, @FullName, @Gender, @DateOfBirth, @Email, @PhoneNumber, 1, @DepartmentID)";
                        using (SqlCommand userCmd = new SqlCommand(insertUserQuery, connection))
                        {
                            userCmd.Parameters.AddWithValue("@UserID", userID);
                            userCmd.Parameters.AddWithValue("@Username", userID);
                            userCmd.Parameters.AddWithValue("@Password", password);
                            userCmd.Parameters.AddWithValue("@FullName", fullName);
                            userCmd.Parameters.AddWithValue("@Email", email);
                            userCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                            userCmd.Parameters.AddWithValue("@DepartmentID", newDepartmentID);
                            userCmd.Parameters.AddWithValue("@Gender", gender);
                            userCmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);

                            userCmd.ExecuteNonQuery(); // Thực thi câu lệnh INSERT người dùng
                        }

                        // Gửi email thông báo cho người dùng
                        SendEmailToUser(email, userID, password);

                        MessageBox.Show("Department and user added successfully.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    this.Close();
                }
            }
        }



        // Kiểm tra tính hợp lệ của email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Kiểm tra tính hợp lệ của mật khẩu
        private bool IsValidPassword(string password)
        {
            if (password.Length < 6)
                return false;

            bool hasLetter = false;
            bool hasDigit = false;
            foreach (char c in password)
            {
                if (Char.IsLetter(c)) hasLetter = true;
                if (Char.IsDigit(c)) hasDigit = true;
            }
            return hasLetter && hasDigit;
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

                MessageBox.Show("Send email successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDepartmentName_TextChanged(object sender, EventArgs e)
        {
            string departmentName = txtDepartmentName.Text.Replace(" ", "");
            string prefix = "";
            if (departmentName.Length >= 4)
            {
                prefix = departmentName.Trim().Substring(0, 4).ToUpper();
            }
            if (string.IsNullOrEmpty(departmentName) || departmentName.Length < 4)
            {
                txtUserID.Text = ""; // Xóa nếu tên phòng không hợp lệ
                //return;
                prefix = departmentName.Trim().Substring(0, departmentName.Length).ToUpper();
            }

            // Lấy 4 ký tự đầu tiên viết hoa từ tên phòng

            // Kết nối tới cơ sở dữ liệu để kiểm tra tồn tại
            string query = $"SELECT UserID FROM [User] WHERE UserID LIKE '{prefix}%'";
            List<string> existingUserIDs = new List<string>();

            using (SqlConnection conn = new SqlConnection(Program.connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        existingUserIDs.Add(reader.GetString(0)); // Lấy UserID
                    }
                }
            }

            // Tìm số thứ tự lớn nhất
            int maxNumber = 0;
            foreach (string userID in existingUserIDs)
            {
                string numberPart = userID.Substring(4); // Lấy phần số
                if (int.TryParse(numberPart, out int number) && number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            // Tăng số lên 1
            int nextNumber = maxNumber + 1;
            string newUserID = $"{prefix}{nextNumber:000}";

            // Hiển thị UserID mới
            txtUserID.Text = newUserID;
        }
    }
}
