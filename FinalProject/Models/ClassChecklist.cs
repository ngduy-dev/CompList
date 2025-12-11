using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;  // Thư viện tạo QR code (cần cài đặt thư viện QRCoder)

namespace FinalProject.Models
{
    public class ClassChecklist
    {
        // Các thuộc tính của class Checklist tương ứng với các trường trong bảng Checklist
        public string ChecklistID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedByID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; }
        public string DepartmentID { get; set; }

        // Hàm tạo checklist mới (INSERT vào cơ sở dữ liệu)
        public bool CreateChecklist(SqlConnection conn)
        {
            try
            {
                string query = @"
                    INSERT INTO [Checklist] 
                    ([ChecklistID], [Title], [Description], [CreatedByID], [CreatedDate], [DueDate], [Status], [DepartmentID])
                    VALUES (@ChecklistID, @Title, @Description, @CreatedByID, @CreatedDate, @DueDate, @Status, @DepartmentID)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ChecklistID", ChecklistID);
                cmd.Parameters.AddWithValue("@Title", Title);
                cmd.Parameters.AddWithValue("@Description", Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CreatedByID", CreatedByID);
                cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                cmd.Parameters.AddWithValue("@DueDate", DueDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", Status ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating checklist: " + ex.Message);
                return false;
            }
        }

        // Hàm cập nhật checklist (UPDATE vào cơ sở dữ liệu)
        public bool UpdateChecklist(SqlConnection conn)
        {
            try
            {
                string query = @"
                    UPDATE [Checklist]
                    SET [Title] = @Title, [Description] = @Description, [DueDate] = @DueDate, [Status] = @Status, [DepartmentID] = @DepartmentID
                    WHERE [ChecklistID] = @ChecklistID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ChecklistID", ChecklistID);
                cmd.Parameters.AddWithValue("@Title", Title);
                cmd.Parameters.AddWithValue("@Description", Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DueDate", DueDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", Status ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating checklist: " + ex.Message);
                return false;
            }
        }

        // Hàm xóa checklist (DELETE từ cơ sở dữ liệu)
        public bool DeleteChecklist(SqlConnection conn)
        {
            try
            {
                string query = "DELETE FROM [Checklist] WHERE [ChecklistID] = @ChecklistID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ChecklistID", ChecklistID);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting checklist: " + ex.Message);
                return false;
            }
        }

        // Hàm tạo QR Code cho checklist
        public Image GenerateQRCode()
        {
            try
            {
                string qrText = $"ChecklistID: {ChecklistID}\nTitle: {Title}\nDueDate: {DueDate?.ToString("yyyy-MM-dd")}\nStatus: {Status}";
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                return qrCodeImage;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating QR code: " + ex.Message);
                return null;
            }
        }
    }
}
