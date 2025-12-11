using System;
using System.Data;
using System.Data.SqlClient;

namespace FinalProject.Repositories
{
    internal class RepositoryUser
    {
        private readonly string connectionString = Program.connectionString;

        // Method for User Login
        public bool Login(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM [User] WHERE Username = @Username AND Password = @Password AND IsActive = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                return userCount > 0; // Return true if user exists and is active
            }
        }

        // Method for changing password
        public bool ChangePassword(string userID, string newPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE [User] SET Password = @NewPassword WHERE UserID = @UserID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                cmd.Parameters.AddWithValue("@UserID", userID);

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                return result > 0; // Return true if password was successfully changed
            }
        }

        // Method for resetting password
        public bool ResetPassword(string userID, string defaultPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE [User] SET Password = @DefaultPassword WHERE UserID = @UserID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DefaultPassword", defaultPassword);
                cmd.Parameters.AddWithValue("@UserID", userID);

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                return result > 0; // Return true if password was successfully reset
            }
        }
    }
}
