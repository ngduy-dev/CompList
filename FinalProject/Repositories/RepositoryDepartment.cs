using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FinalProject.Repositories
{
    internal class RepositoryDepartment
    {
        private readonly string connectionString = Program.connectionString;

        // Thêm mới Department
        public bool CreateDepartment(ClassDepartment department)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [Department] (DepartmentID, DepartmentName) VALUES (@DepartmentID, @DepartmentName)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
                cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Cập nhật Department
        public bool UpdateDepartment(ClassDepartment department)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE [Department] SET DepartmentName = @DepartmentName WHERE DepartmentID = @DepartmentID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                cmd.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Xóa Department
        public bool DeleteDepartment(string departmentID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM [Department] WHERE DepartmentID = @DepartmentID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DepartmentID", departmentID);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Lấy thông tin tất cả các Department
        public List<ClassDepartment> GetDepartments()
        {
            List<ClassDepartment> departments = new List<ClassDepartment>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [Department]";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClassDepartment department = new ClassDepartment
                    {
                        DepartmentID = reader["DepartmentID"].ToString(),
                        DepartmentName = reader["DepartmentName"].ToString()
                    };
                    departments.Add(department);
                }
            }

            return departments;
        }

        // Lấy báo cáo theo DepartmentID
        public List<ClassReport> GetReportsByDepartmentID(string departmentID)
        {
            List<ClassReport> reports = new List<ClassReport>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [Report] WHERE DepartmentID = @DepartmentID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DepartmentID", departmentID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClassReport report = new ClassReport
                    {
                        ReportID = Convert.ToInt32(reader["ReportID"]),
                        DepartmentID = reader["DepartmentID"].ToString(),
                        GeneratedDate = Convert.ToDateTime(reader["GeneratedDate"]),
                        ReportType = reader["ReportType"].ToString(),
                        StatusFilter = reader["StatusFilter"].ToString(),
                        FooterNotes = reader["FooterNotes"].ToString()
                    };
                    reports.Add(report);
                }
            }

            return reports;
        }
    }
}
