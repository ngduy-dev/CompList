using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FinalProject.Repositories
{
    internal class RepositoryQRCode
    {
        private readonly string connectionString = Program.connectionString;

        // Generate QR Code and save to database
        public bool GenerateQRCode(string checklistID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [QRCode] (ChecklistID, GeneratedDate, ExpirationDate, IsExpired) " +
                               "VALUES (@ChecklistID, @GeneratedDate, @ExpirationDate, @IsExpired)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ChecklistID", checklistID);
                cmd.Parameters.AddWithValue("@GeneratedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ExpirationDate", DateTime.Now.AddMonths(1));  // Example expiration date
                cmd.Parameters.AddWithValue("@IsExpired", 0); // QR code initially not expired

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Validate QR Code based on ChecklistID
        public bool ValidateQRCode(string qrCodeID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT IsExpired FROM [QRCode] WHERE QRCodeID = @QRCodeID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@QRCodeID", qrCodeID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    bool isExpired = Convert.ToBoolean(reader["IsExpired"]);
                    return !isExpired;  // QR code is valid if it's not expired
                }
                return false; // Return false if no QR code found
            }
        }
    }
}
