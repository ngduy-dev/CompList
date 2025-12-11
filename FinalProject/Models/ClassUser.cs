using System;
using System.Data.SqlClient;

namespace FinalProject.Models
{
    public class ClassUser
    {
        // Các thuộc tính của class User tương ứng với các trường trong bảng User
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
        public string DepartmentID { get; set; }

        // Hàm đăng nhập (Login)
        public bool Login(SqlConnection conn, string username, string password)
        {
            try
            {
                string query = @"
                    SELECT [UserID], [FullName], [IsActive] 
                    FROM [User] 
                    WHERE [Username] = @Username AND [Password] = @Password";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    UserID = reader["UserID"].ToString();
                    FullName = reader["FullName"].ToString();
                    IsActive = Convert.ToBoolean(reader["IsActive"]);

                    conn.Close();

                    // Kiểm tra trạng thái tài khoản
                    if (IsActive)
                    {
                        // Cập nhật thời gian đăng nhập
                        UpdateLastLogin(conn);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Account is inactive.");
                        return false;
                    }
                }

                conn.Close();
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during login: " + ex.Message);
                return false;
            }
        }

        // Hàm đăng xuất (Logout)
        public void Logout()
        {
            // Có thể xóa thông tin đăng nhập trong phiên làm việc hoặc hệ thống
            Console.WriteLine("User has logged out.");
        }

        // Hàm thay đổi mật khẩu (Change Password)
        public bool ChangePassword(SqlConnection conn, string oldPassword, string newPassword)
        {
            try
            {
                string query = @"
                    UPDATE [User]
                    SET [Password] = @NewPassword
                    WHERE [UserID] = @UserID AND [Password] = @OldPassword";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@OldPassword", oldPassword);
                cmd.Parameters.AddWithValue("@NewPassword", newPassword);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error changing password: " + ex.Message);
                return false;
            }
        }

        // Hàm đặt lại mật khẩu (Reset Password)
        public bool ResetPassword(SqlConnection conn, string email)
        {
            try
            {
                string newPassword = "Temporary1234";  // Tạo mật khẩu tạm thời (có thể thay đổi)
                string query = @"
                    UPDATE [User]
                    SET [Password] = @NewPassword
                    WHERE [Email] = @Email";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@NewPassword", newPassword);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error resetting password: " + ex.Message);
                return false;
            }
        }

        // Cập nhật thời gian đăng nhập
        private void UpdateLastLogin(SqlConnection conn)
        {
            try
            {
                string query = @"
                    UPDATE [User]
                    SET [LastLogin] = @LastLogin
                    WHERE [UserID] = @UserID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@LastLogin", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating last login: " + ex.Message);
            }
        }
    }
}
