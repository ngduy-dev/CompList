using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalProject.Views
{
    public partial class FormUpdateChecklist : Form, ILocalizable
    {
        private string checklistID;
        //private string connectionString = "Data Source=MSIBRAVO15\\QUOCDUY;Initial Catalog=CHECKLIST;Integrated Security=True";
        private string connectionString = Program.connectionString;


        // Các biến lưu thông tin ban đầu
        private string initialTitle;
        private string initialDescription;
        private DateTime initialDueDate;
        private string initialStatus;
        private string initialDepartmentID;
        private string initialCreatedByID;
        public FormUpdateChecklist(string checklistID)
        {
            InitializeComponent();
            this.checklistID = checklistID;

            LoadDepartmentsIntoComboBox();
            LoadInitialData();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            lblUpdateChecklist.Text = LanguageManager.Translate("updatecl");
            lblTitle.Text = LanguageManager.Translate("title");
            txtDescription.Text = LanguageManager.Translate("description");
            lblStatus.Text = LanguageManager.Translate("status");
            lblDepartment.Text = LanguageManager.Translate("department");
            lblDueDate.Text = LanguageManager.Translate("due_date");
            btnSaveChecklist.Text = LanguageManager.Translate("save");
        }


        private void LoadDepartmentsIntoComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DepartmentID, DepartmentName FROM Department";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    cmbDepartment.DataSource = dataTable;
                    cmbDepartment.DisplayMember = "DepartmentName";
                    cmbDepartment.ValueMember = "DepartmentID";
                }
            }
        }

        private void LoadInitialData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Title, Description, DueDate, Status, DepartmentID, CreatedByID FROM Checklist WHERE ChecklistID = @ChecklistID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ChecklistID", checklistID);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Gán các giá trị cho các biến
                        initialTitle = reader["Title"].ToString();
                        initialDescription = reader["Description"].ToString();
                        initialDueDate = Convert.ToDateTime(reader["DueDate"]);
                        initialStatus = reader["Status"].ToString();
                        initialDepartmentID = reader["DepartmentID"].ToString();  // Đổi thành string
                        initialCreatedByID = UserSession.UserID;  

                        // Hiển thị thông tin lên giao diện
                        lblUpdateChecklist.Text = $"Update Checklist {this.checklistID}";
                        txtTitle.Text = initialTitle;
                        txtDescription.Text = initialDescription;
                        dtpDueDate.Value = initialDueDate;

                        cmbStatus.ValueMember = "Value"; // Giá trị đại diện trong danh sách
                        cmbStatus.DisplayMember = "Text"; // Giá trị hiển thị
                        cmbStatus.DataSource = new List<dynamic>
                        {
                            new { Value = "Complete", Text = "Complete" },
                            new { Value = "Open", Text = "Open" },
                            new { Value = "In Progress", Text = "In Progress" },
                            new { Value = "Closed", Text = "Closed" }
                        };
                        cmbStatus.SelectedValue = initialStatus;

                        // Đặt giá trị cho comboBoxDepartment và comboBoxCreatedBy
                        // Nếu DepartmentID là kiểu string, bạn cần điều chỉnh cách xử lý giá trị cho comboBoxDepartment
                        cmbDepartment.SelectedValue = initialDepartmentID;  // Chỉnh lại kiểu cho DepartmentID
                    }
                }
            }
        }

        private void buttonSaveChecklist_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có thay đổi trên giao diện
            string updatedTitle = txtTitle.Text;
            string updatedDescription = txtDescription.Text;
            DateTime updatedDueDate = dtpDueDate.Value;
            DateTime dueDate = dtpDueDate.Value;
            if (dueDate.Date < DateTime.Today)
            {
                MessageBox.Show("Due date cannot be before today.", "Invalid Due Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string updatedStatus = cmbStatus.Text;
            string updatedDepartmentID = cmbDepartment.SelectedValue.ToString();  // Đổi thành string

            // Kiểm tra nếu các giá trị đã thay đổi so với ban đầu
            if (updatedTitle != initialTitle || updatedDescription != initialDescription ||
                updatedDueDate != initialDueDate || updatedStatus != initialStatus || updatedDepartmentID != initialDepartmentID)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE Checklist SET Title = @Title, Description = @Description, DueDate = @DueDate, " +
                                       "Status = @Status, DepartmentID = @DepartmentID " +
                                       "WHERE ChecklistID = @ChecklistID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Thêm các tham số để tránh SQL Injection
                            command.Parameters.AddWithValue("@Title", updatedTitle);
                            command.Parameters.AddWithValue("@Description", updatedDescription);
                            command.Parameters.AddWithValue("@DueDate", updatedDueDate);
                            command.Parameters.AddWithValue("@Status", updatedStatus);
                            command.Parameters.AddWithValue("@DepartmentID", updatedDepartmentID); 
                            command.Parameters.AddWithValue("@ChecklistID", checklistID);

                            int rowsAffected = command.ExecuteNonQuery();

                            // Kiểm tra nếu cập nhật thành công
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Checklist updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("No changes were made.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No changes detected.");
            }
        }
    }
}
