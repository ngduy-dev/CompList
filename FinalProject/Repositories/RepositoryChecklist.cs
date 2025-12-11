using System;
using System.Data;
using System.Data.SqlClient;
using FinalProject.Models;

namespace FinalProject.Repositories
{
    public class RepositoryChecklist
    {
        private readonly string _connectionString;

        public RepositoryChecklist(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Phương thức tạo Checklist
        public bool CreateChecklist(ClassChecklist checklist)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "INSERT INTO Checklist (ChecklistID, Title, Description, CreatedByID, CreatedDate, DueDate, Status, DepartmentID) " +
                                   "VALUES (@ChecklistID, @Title, @Description, @CreatedByID, @CreatedDate, @DueDate, @Status, @DepartmentID)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ChecklistID", checklist.ChecklistID);
                    cmd.Parameters.AddWithValue("@Title", checklist.Title);
                    cmd.Parameters.AddWithValue("@Description", checklist.Description);
                    cmd.Parameters.AddWithValue("@CreatedByID", checklist.CreatedByID);
                    cmd.Parameters.AddWithValue("@CreatedDate", checklist.CreatedDate);
                    cmd.Parameters.AddWithValue("@DueDate", checklist.DueDate);
                    cmd.Parameters.AddWithValue("@Status", checklist.Status);
                    cmd.Parameters.AddWithValue("@DepartmentID", checklist.DepartmentID);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Trả về true nếu đã chèn thành công
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // Phương thức cập nhật Checklist
        public bool UpdateChecklist(ClassChecklist checklist)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "UPDATE Checklist SET Title = @Title, Description = @Description, DueDate = @DueDate, Status = @Status " +
                                   "WHERE ChecklistID = @ChecklistID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ChecklistID", checklist.ChecklistID);
                    cmd.Parameters.AddWithValue("@Title", checklist.Title);
                    cmd.Parameters.AddWithValue("@Description", checklist.Description);
                    cmd.Parameters.AddWithValue("@DueDate", checklist.DueDate);
                    cmd.Parameters.AddWithValue("@Status", checklist.Status);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Trả về true nếu cập nhật thành công
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // Phương thức xóa Checklist
        public bool DeleteChecklist(string checklistID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "DELETE FROM Checklist WHERE ChecklistID = @ChecklistID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ChecklistID", checklistID);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Trả về true nếu xóa thành công
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // Phương thức lấy thông tin Checklist theo ID
        public ClassChecklist GetChecklistByID(string checklistID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Checklist WHERE ChecklistID = @ChecklistID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ChecklistID", checklistID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        ClassChecklist checklist = new ClassChecklist
                        {
                            ChecklistID = reader["ChecklistID"].ToString(),
                            Title = reader["Title"].ToString(),
                            Description = reader["Description"].ToString(),
                            CreatedByID = reader["CreatedByID"].ToString(),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                            DueDate = reader["DueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DueDate"]),
                            Status = reader["Status"].ToString(),
                            DepartmentID = reader["DepartmentID"].ToString()
                        };
                        return checklist;
                    }
                    return null; // Trả về null nếu không tìm thấy
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }
        }

        // Phương thức tạo QRCode (giả sử bạn có một phương thức tạo QR code nào đó)
        public string GenerateQRCode(string checklistID)
        {
            // Bạn có thể gọi một service hay thư viện để tạo QR code tại đây
            // Ví dụ: trả về một đường link QR code cho checklist
            return "QRCodeFor" + checklistID;
        }
    }
}
