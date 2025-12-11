using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FinalProject.Repositories
{
    internal class RepositoryEmployee
    {
        private readonly string connectionString = Program.connectionString;

        // Nhận checklist được giao cho nhân viên
        public List<ClassChecklist> ReceiveChecklist(string employeeID)
        {
            List<ClassChecklist> checklists = new List<ClassChecklist>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT c.* FROM [Checklist] c " +
                               "INNER JOIN [ChecklistItem] ci ON c.ChecklistID = ci.ChecklistID " +
                               "WHERE ci.EmployeeID = @EmployeeID AND ci.IsCompleted = 0";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClassChecklist checklist = new ClassChecklist
                    {
                        ChecklistID = reader["ChecklistID"].ToString(),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        CreatedByID = reader["CreatedByID"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                        DueDate = reader["DueDate"] != DBNull.Value ? Convert.ToDateTime(reader["DueDate"]) : (DateTime?)null,
                        Status = reader["Status"].ToString(),
                        DepartmentID = reader["DepartmentID"].ToString()
                    };
                    checklists.Add(checklist);
                }
            }

            return checklists;
        }

        // Gửi lại form đã hoàn thành
        public bool SubmitForm(string itemID, bool isCompleted)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE [ChecklistItem] SET IsCompleted = @IsCompleted WHERE ItemID = @ItemID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ItemID", itemID);
                cmd.Parameters.AddWithValue("@IsCompleted", isCompleted);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Xem danh sách checklist đã được giao cho nhân viên
        public List<ClassChecklistItem> ViewAssignedChecklist(string employeeID)
        {
            List<ClassChecklistItem> assignedChecklists = new List<ClassChecklistItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ci.ItemID, ci.TaskDescription, ci.IsCompleted, c.ChecklistID, c.Title " +
                               "FROM [ChecklistItem] ci " +
                               "INNER JOIN [Checklist] c ON ci.ChecklistID = c.ChecklistID " +
                               "WHERE ci.EmployeeID = @EmployeeID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClassChecklistItem checklistItem = new ClassChecklistItem
                    {
                        ItemID = reader["ItemID"].ToString(),
                        TaskDescription = reader["TaskDescription"].ToString(),
                        IsCompleted = Convert.ToBoolean(reader["IsCompleted"]),
                        ChecklistID = reader["ChecklistID"].ToString(),
                    };
                    assignedChecklists.Add(checklistItem);
                }
            }

            return assignedChecklists;
        }
    }
}
