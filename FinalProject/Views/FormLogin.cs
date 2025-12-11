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
using FluentEmail.Core;
using System.Net.Mail;
using System.Net;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinalProject.Views
{
    public partial class FormLogin : Form
    {
        SqlConnection conn = new SqlConnection(Program.connectionString);
        public FormLogin()
        {
            InitializeComponent();
        }

        private Image eyeClosed = Properties.Resources.hide; // Ảnh nhắm mắt
        private Image eyeOpen = Properties.Resources.show;     // Ảnh mở mắt
        private bool isPasswordVisible = false;


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            try
            {
                conn.Open();
                string userID = txtUserID.Text;
                string password = txtPassword.Text;

                // Truy vấn thông tin người dùng từ cơ sở dữ liệu
                string sql = "SELECT Username, FullName, Email, IsActive, DepartmentID FROM [User] WHERE UserID = @UserID AND Password = @Password";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    if (rdr["IsActive"].ToString() == "False")
                    {
                        MessageBox.Show("Your account was blocked.");
                        return;
                    }

                    // Lưu thông tin vào UserSession
                    UserSession.UserID = userID;
                    UserSession.UserPassword = password;
                    UserSession.Username = rdr["Username"].ToString();  // Username (tên tài khoản)
                    UserSession.FullName = rdr["FullName"].ToString(); // Tên đầy đủ
                    UserSession.Email = rdr["Email"].ToString(); // Email
                    UserSession.IsDirector = userID.ToUpper().StartsWith("DIRE");
                    UserSession.DepartmentID = rdr["DepartmentID"]?.ToString();

                    string departmentID = rdr["DepartmentID"].ToString();
                    // Lấy tên phòng ban từ DepartmentID
                    string departmentName = GetDepartmentName(departmentID);
                    UserSession.Position = departmentName;  // Gán DepartmentName vào UserSession.Position

                    // Mở form menu chính
                    FormMenu main = new FormMenu();
                    this.Hide();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("UserID hoặc Password không đúng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            finally
            {
                // Đảm bảo đóng kết nối khi kết thúc
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        // Hàm lấy tên phòng ban từ DepartmentID
        private string GetDepartmentName(string departmentID)
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            string departmentName = string.Empty;
            try
            {
                conn.Open();
                string departmentQuery = "SELECT DepartmentName FROM [Department] WHERE DepartmentID = @DepartmentID";
                SqlCommand deptCmd = new SqlCommand(departmentQuery, conn);
                deptCmd.Parameters.AddWithValue("@DepartmentID", departmentID);

                object result = deptCmd.ExecuteScalar();

                if (result != null)
                {
                    departmentName = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin phòng ban: " + ex.Message);
            }

            return departmentName;
        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            gbxForgetPass.Visible = true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            gbxForgetPass.Visible = false;
        }
        private bool IsEmailExists(string email)
        {
            bool exists = false;

            string connectionString = Program.connectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Câu lệnh SQL kiểm tra email
                    string query = "SELECT COUNT(*) FROM [User] WHERE Email = @Email";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        int count = (int)command.ExecuteScalar();
                        exists = count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kiểm tra email: {ex.Message}");
                }
            }

            return exists;
        }
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
        private void SendOtpToEmail(string email, string otp)
        {
            // Cấu hình SMTP
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("cnpmquatrinh2@gmail.com", "eqyr zjud dbgn hbik"), 
                EnableSsl = true,
            };

            // Nội dung email
            var mailMessage = new MailMessage
            {
                From = new MailAddress("cnpmquatrinh2@gmail.com"), // Email người gửi
                Subject = "Mã OTP để đặt lại mật khẩu",
                Body = $"Xin chào,\n\nMã OTP của bạn để đặt lại mật khẩu là: {otp}\n\nVui lòng không chia sẻ mã này với bất kỳ ai.\n\nCảm ơn!",
                IsBodyHtml = false, // Nội dung dạng văn bản
            };

            mailMessage.To.Add(email); // Gửi đến email nhận

            try
            {
                smtpClient.Send(mailMessage);
                MessageBox.Show("Mã OTP đã được gửi đến email của bạn.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi email: {ex.Message}");
            }
        }
        private string GenerateOTP()
        {
            Random rd = new Random();
            return rd.Next(100000, 999999).ToString();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            string email = txtEnterEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.");
                return;
            }

            if (IsEmailExists(email))
            {
                string otp = GenerateOTP();
                SendOtpToEmail(email, otp);
                gbxForgetPass.Visible = false;
                FormResetPassword resetPassword = new FormResetPassword(email, otp);
                resetPassword.ShowDialog();
            }
            else
            {
                MessageBox.Show("Email không tồn tại trong hệ thống.");
            }
        }

        private void pbShowPassword_Click(object sender, EventArgs e)
        {
            // Đổi trạng thái hiển thị mật khẩu
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtPassword.PasswordChar = '\0'; // Hiển thị mật khẩu
                pbShowPassword.Image = Properties.Resources.show; // Đổi hình ảnh thành "mở mắt"
            }
            else
            {
                txtPassword.PasswordChar = '●'; // Ẩn mật khẩu
                pbShowPassword.Image = Properties.Resources.hide; // Đổi hình ảnh thành "nhắm mắt"
            }
        }
    }

    public static class UserSession
    { 
        public static string Username { get; set; }
        public static string FullName { get; set; } // Thêm FullName
        public static string Email { get; set; } // Thêm Email
        public static string UserID { get; set; }
        public static string UserPassword { get; set; }
        public static string Position { get; set; }
        public static bool IsDirector { get; set; }
        public static string DepartmentID { get; set; }
        //public static bool IsDirector
        //{
        //    get
        //    {
        //        return UserID != null && UserID.StartsWith("DIRE");
        //    }
        //}
        static UserSession()
        {
            // Khởi tạo mặc định
            FullName = "Nguyễn Văn Giám Đốc";
            Email = "giamsod@companyname.com";
            UserID = "DIRE001";
            UserPassword = "Pass1234";
            Position = "Giám Đốc";
            IsDirector = true;
        }
    }
}
