using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalProject.Views
{
    public partial class FormResetPassword : Form
    {
        private string email;
        private string otp;

        public FormResetPassword(string email, string otp)
        {
            InitializeComponent();
            this.email = email;
            this.otp = otp;
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool IsPasswordValid(string password)
        {
            // Check password length
            if (password.Length < 8)
                return false;

            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;

            // Check each character in the password
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                if (char.IsLower(c))
                {
                    hasLowerCase = true;
                }
                if (char.IsDigit(c))
                {
                    hasDigit = true;
                }

                // If all conditions are met, no need to check further
                if (hasUpperCase && hasLowerCase && hasDigit)
                {
                    return true;
                }
            }

            return false;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string enteredOtp = txtOTP.Text.Trim();
            string newPassword = txtNewPass.Text.Trim();
            string verifyPassword = txtVerifyNewPass.Text.Trim();

            if (string.IsNullOrEmpty(enteredOtp))
            {
                MessageBox.Show("Please enter the OTP.");
                return;
            }
            if (enteredOtp != otp)
            {
                MessageBox.Show("The OTP is incorrect.");
                return;
            }
            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter a new password.");
                return;
            }
            if (string.IsNullOrEmpty(verifyPassword))
            {
                MessageBox.Show("Please confirm your new password.");
                return;
            }
            if (newPassword != verifyPassword)
            {
                MessageBox.Show("The confirmation password does not match.");
                return;
            }
            if (!IsPasswordValid(newPassword))
            {
                MessageBox.Show("The password must be at least 8 characters long and contain lowercase, uppercase letters, and a digit.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE [User] SET Password = @Password WHERE Email = @Email";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Password", newPassword);
                        command.Parameters.AddWithValue("@Email", email);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("The password has been successfully updated.");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Email not found in the system. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
