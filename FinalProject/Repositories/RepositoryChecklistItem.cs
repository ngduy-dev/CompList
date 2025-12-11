using System;
using System.Data;
using System.Data.SqlClient;
using FinalProject.Models;

namespace FinalProject.Repositories
{
    public class RepositoryChecklistItem
    {
        private readonly string _connectionString;

        public RepositoryChecklistItem(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Phương thức tạo ChecklistItem
        public bool CreateChecklistItem(ClassChecklistItem item)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "INSERT INTO ChecklistItem (ItemID, ChecklistID, TaskDescription, IsCompleted, DueDate, EmployeeID) " +
                                   "VALUES (@ItemID, @ChecklistID, @TaskDescription, @IsCompleted, @DueDate, @EmployeeID)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ItemID", item.ItemID);
                    cmd.Parameters.AddWithValue("@ChecklistID", item.ChecklistID);
                    cmd.Parameters.AddWithValue("@TaskDescription", item.TaskDescription);
                    cmd.Parameters.AddWithValue("@IsCompleted", item.IsCompleted);
                    cmd.Parameters.AddWithValue("@DueDate", item.DueDate);
                    cmd.Parameters.AddWithValue("@EmployeeID", item.EmployeeID);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Trả về true nếu tạo thành công
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // Phương thức cập nhật ChecklistItem
        public bool UpdateTask(ClassChecklistItem item)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "UPDATE ChecklistItem SET TaskDescription = @TaskDescription, IsCompleted = @IsCompleted, " +
                                   "DueDate = @DueDate, EmployeeID = @EmployeeID WHERE ItemID = @ItemID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ItemID", item.ItemID);
                    cmd.Parameters.AddWithValue("@TaskDescription", item.TaskDescription);
                    cmd.Parameters.AddWithValue("@IsCompleted", item.IsCompleted);
                    cmd.Parameters.AddWithValue("@DueDate", item.DueDate);
                    cmd.Parameters.AddWithValue("@EmployeeID", item.EmployeeID);

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

        // Phương thức xóa ChecklistItem
        public bool DeleteChecklistItem(string itemID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "DELETE FROM ChecklistItem WHERE ItemID = @ItemID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ItemID", itemID);

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

        // Phương thức lấy ChecklistItem theo ID
        public ClassChecklistItem GetChecklistItemByID(string itemID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM ChecklistItem WHERE ItemID = @ItemID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ItemID", itemID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        ClassChecklistItem item = new ClassChecklistItem
                        {
                            ItemID = reader["ItemID"].ToString(),
                            ChecklistID = reader["ChecklistID"].ToString(),
                            TaskDescription = reader["TaskDescription"].ToString(),
                            IsCompleted = Convert.ToBoolean(reader["IsCompleted"]),
                            DueDate = reader["DueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DueDate"]),
                            EmployeeID = reader["EmployeeID"].ToString()
                        };
                        return item;
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

        // Phương thức thông báo cho nhân viên về nhiệm vụ
        public bool NotifyEmployeeOnTask(string itemID)
        {
            // Giả sử chúng ta sẽ lấy thông tin nhân viên từ ItemID và gửi email thông báo
            var item = GetChecklistItemByID(itemID);
            if (item != null && !item.IsCompleted)
            {
                // Tạo một thông báo (có thể là email hoặc thông báo ứng dụng)
                // Ở đây sẽ là giả lập gửi email thông qua một dịch vụ nào đó
                Console.WriteLine($"Gửi thông báo cho nhân viên {item.EmployeeID}: {item.TaskDescription}");
                return true;
            }
            return false;
        }
    }
}
