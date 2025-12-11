using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public class ClassEmployee
    {
        // Các thuộc tính của class Employee tương ứng với các trường trong bảng Employee
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string NumberPhone { get; set; }
        public string DepartmentID { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        // Hàm nhận checklist (Receive Checklist)
        public List<ClassChecklistItem> ReceiveChecklist(SqlConnection conn, string employeeID)
        {
            try
            {
                List<ClassChecklistItem> checklistItems = new List<ClassChecklistItem>();

                string query = @"
                    SELECT ci.[ItemID], ci.[ChecklistID], ci.[TaskDescription], ci.[IsCompleted], ci.[DueDate]
                    FROM [ChecklistItem] ci
                    INNER JOIN [Checklist] c ON ci.ChecklistID = c.ChecklistID
                    WHERE ci.EmployeeID = @EmployeeID AND ci.IsCompleted = 0";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ClassChecklistItem item = new ClassChecklistItem
                    {
                        ItemID = reader["ItemID"].ToString(),
                        ChecklistID = reader["ChecklistID"].ToString(),
                        TaskDescription = reader["TaskDescription"].ToString(),
                        IsCompleted = Convert.ToBoolean(reader["IsCompleted"]),
                        DueDate = Convert.ToDateTime(reader["DueDate"])
                    };

                    checklistItems.Add(item);
                }

                conn.Close();
                return checklistItems;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error receiving checklist: " + ex.Message);
                return null;
            }
        }

        // Hàm nộp form (Submit Form)
        public bool SubmitForm(SqlConnection conn, string itemID)
        {
            try
            {
                string query = @"
                    UPDATE [ChecklistItem]
                    SET [IsCompleted] = 1
                    WHERE [ItemID] = @ItemID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ItemID", itemID);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error submitting form: " + ex.Message);
                return false;
            }
        }

        // Hàm xem danh sách checklist được phân công (View Assigned Checklist)
        public List<ClassChecklistItem> ViewAssignedChecklist(SqlConnection conn, string employeeID)
        {
            try
            {
                List<ClassChecklistItem> checklistItems = new List<ClassChecklistItem>();

                string query = @"
                    SELECT ci.[ItemID], ci.[ChecklistID], ci.[TaskDescription], ci.[IsCompleted], ci.[DueDate]
                    FROM [ChecklistItem] ci
                    WHERE ci.EmployeeID = @EmployeeID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ClassChecklistItem item = new ClassChecklistItem
                    {
                        ItemID = reader["ItemID"].ToString(),
                        ChecklistID = reader["ChecklistID"].ToString(),
                        TaskDescription = reader["TaskDescription"].ToString(),
                        IsCompleted = Convert.ToBoolean(reader["IsCompleted"]),
                        DueDate = Convert.ToDateTime(reader["DueDate"])
                    };

                    checklistItems.Add(item);
                }

                conn.Close();
                return checklistItems;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error viewing assigned checklist: " + ex.Message);
                return null;
            }
        }
    }
}
