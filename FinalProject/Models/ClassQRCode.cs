using QRCoder;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;

namespace FinalProject.Models
{
    public class QRCodeModel
    {
        // Các thuộc tính của class QRCode
        public int QRCodeID { get; set; }
        public string ChecklistID { get; set; }
        public DateTime GeneratedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsExpired { get; set; }

        // Hàm tạo QR Code
        public bool GenerateQRCode(SqlConnection conn, string checklistID)
        {
            try
            {
                // Dữ liệu để tạo mã QR
                string qrData = "ChecklistID:" + checklistID + "\nGenerated Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Tạo QR Code data
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);

                // Tạo mã QR từ QRCodeData
                QRCode qrCode = new QRCode(qrCodeData); // Không phải constructor đơn giản

                // Tạo hình ảnh QR
                Bitmap qrCodeImage = qrCode.GetGraphic(20); // Tạo mã QR với kích thước khối là 20

                // Lưu ảnh QR vào hệ thống
                string qrCodePath = @"C:\QRCodeImages\" + checklistID + ".png"; // Đảm bảo thư mục tồn tại
                qrCodeImage.Save(qrCodePath, ImageFormat.Png);

                // Lưu thông tin vào cơ sở dữ liệu
                string query = @"
                    INSERT INTO [QRCode] ([ChecklistID], [GeneratedDate], [ExpirationDate], [IsExpired])
                    VALUES (@ChecklistID, @GeneratedDate, @ExpirationDate, @IsExpired)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ChecklistID", checklistID);
                cmd.Parameters.AddWithValue("@GeneratedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ExpirationDate", DateTime.Now.AddDays(30)); // Set expiration to 30 days
                cmd.Parameters.AddWithValue("@IsExpired", false);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0; // Trả về true nếu QR Code được tạo thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating QR Code: " + ex.Message);
                return false;
            }
        }

        // Hàm kiểm tra tính hợp lệ của QR Code
        public bool ValidateQRCode(SqlConnection conn, string qrCodeID)
        {
            try
            {
                string query = @"
                    SELECT [ExpirationDate], [IsExpired]
                    FROM [QRCode]
                    WHERE [QRCodeID] = @QRCodeID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@QRCodeID", qrCodeID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    DateTime expirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    bool isExpired = Convert.ToBoolean(reader["IsExpired"]);

                    conn.Close();

                    // Kiểm tra nếu QR code đã hết hạn
                    if (isExpired || DateTime.Now > expirationDate)
                    {
                        return false; // QR code đã hết hạn
                    }
                    return true; // QR code hợp lệ
                }
                else
                {
                    conn.Close();
                    return false; // Không tìm thấy QR code
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error validating QR Code: " + ex.Message);
                return false;
            }
        }
    }
}
