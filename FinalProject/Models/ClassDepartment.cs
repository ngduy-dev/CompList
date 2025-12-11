using System;
using System.Data.SqlClient;
using System.Text;

namespace FinalProject.Models
{
    public class ClassDepartment
    {
        // Các thuộc tính của class Department tương ứng với các trường trong bảng Department
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        // Hàm tạo mới Department (INSERT vào cơ sở dữ liệu)
        public bool CreateDepartment(SqlConnection conn)
        {
            try
            {
                string query = @"
                    INSERT INTO [Department] ([DepartmentID], [DepartmentName])
                    VALUES (@DepartmentID, @DepartmentName)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating department: " + ex.Message);
                return false;
            }
        }

        // Hàm cập nhật thông tin Department (UPDATE vào cơ sở dữ liệu)
        public bool UpdateDepartment(SqlConnection conn)
        {
            try
            {
                string query = @"
                    UPDATE [Department]
                    SET [DepartmentName] = @DepartmentName
                    WHERE [DepartmentID] = @DepartmentID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating department: " + ex.Message);
                return false;
            }
        }

        // Hàm xóa Department (DELETE vào cơ sở dữ liệu)
        public bool DeleteDepartment(SqlConnection conn)
        {
            try
            {
                string query = "DELETE FROM [Department] WHERE [DepartmentID] = @DepartmentID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting department: " + ex.Message);
                return false;
            }
        }

        // Hàm lấy báo cáo về tất cả các Department (SELECT từ cơ sở dữ liệu)
        public string GetReport(SqlConnection conn)
        {
            try
            {
                StringBuilder report = new StringBuilder();
                string query = "SELECT [DepartmentID], [DepartmentName] FROM [Department]";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    report.AppendLine($"Department ID: {reader["DepartmentID"]}, Department Name: {reader["DepartmentName"]}");
                }

                conn.Close();
                return report.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating report: " + ex.Message);
                return string.Empty;
            }
        }
    }
}
