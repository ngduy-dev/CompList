using FinalProject.Models;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinalProject.Views
{
    public partial class FormBoard : Form, ILocalizable
    {
        public FormBoard()
        {
            InitializeComponent();
            ApplyLanguage();
        }
        public void ApplyLanguage()
        {
            lblBoard.Text = LanguageManager.Translate("menu_board");
            lblFilter.Text = LanguageManager.Translate("filter");
            btnAllTime.Text = LanguageManager.Translate("btnAllTime");
            btnFilter.Text = LanguageManager.Translate("btnFilter");
            lblDepartment.Text = LanguageManager.Translate("choosechecklistid");
            lblSearch.Text = LanguageManager.Translate("searchchecklist");

            lblChecklistComplete.Text = string.Empty; // Ban đầu để trống
            lblChecklistComplete.Visible = false; // Ẩn nhãn cho đến khi có thao tác

            if (dgvChecklist.Columns.Count > 0)
            {
                //dataGridViewChecklist.Columns["ItemTask"].HeaderText = LanguageManager.Translate("item_task");
                //dataGridViewChecklist.Columns["ChecklistInfo"].HeaderText = LanguageManager.Translate("checklist_info");
                //dataGridViewChecklist.Columns["EmployeeInfo"].HeaderText = LanguageManager.Translate("employee_info");
                //dataGridViewChecklist.Columns["ItemCreateDate"].HeaderText = LanguageManager.Translate("create_date");
                //dataGridViewChecklist.Columns["ItemDueDate"].HeaderText = LanguageManager.Translate("due_date");
                //dataGridViewChecklist.Columns["Status"].HeaderText = LanguageManager.Translate("status");
                //dataGridViewChecklist.Columns["IsCompleted"].HeaderText = LanguageManager.Translate("is_completed");
            }
        }
        private bool isAllTime = false;

        private void Board_Load(object sender, EventArgs e)
        {
            LoadChecklistIDsToComboBox();
            LoadAllChecklists();
            DateTime startDate = btnAllTime.Checked ? new DateTime(1753, 1, 1) : dtpStartDate.Value.Date;
            DateTime endDate = btnAllTime.Checked ? DateTime.MaxValue : dtpEndDate.Value.Date;
            if (endDate < startDate)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void LoadChecklistIDsToComboBox()
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();

                string query = "SELECT ChecklistID FROM Checklist";
                if (!UserSession.IsDirector)
                {
                    query += " WHERE DepartmentID = @UserDepartmentID";
                }
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!UserSession.IsDirector)
                    {
                        command.Parameters.AddWithValue("@UserDepartmentID", UserSession.DepartmentID);
                    }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        cmbChecklist.Items.Clear();
                        while (reader.Read())
                        {
                            cmbChecklist.Items.Add(reader["ChecklistID"].ToString());
                        }
                    }
                }
            }
        }
        public void UpdateProgressBar(string checklistID, DateTime startDate, DateTime endDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    string query = @"
                    SELECT 
                        COUNT(*) AS TotalItems, 
                        SUM(CASE WHEN IsCompleted = 1 THEN 1 ELSE 0 END) AS CompletedItems 
                    FROM ChecklistItem 
                    WHERE ChecklistID = @ChecklistID
                    AND DueDate BETWEEN @StartDate AND @EndDate";

                    if (!UserSession.IsDirector)
                    {
                        query += " AND EXISTS (SELECT 1 FROM Checklist WHERE ChecklistID = @ChecklistID AND DepartmentID = @UserDepartmentID)";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ChecklistID", checklistID);
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        if (!UserSession.IsDirector)
                        {
                            command.Parameters.AddWithValue("@UserDepartmentID", UserSession.DepartmentID);
                        }


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalItems = reader["TotalItems"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TotalItems"]);
                                int completedItems = reader["CompletedItems"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CompletedItems"]);

                                int completionPercentage = (totalItems == 0) ? 0 : (completedItems * 100) / totalItems;
                                prbChecklist.Value = completionPercentage;

                                // Hiển thị nhãn và cập nhật văn bản theo ngôn ngữ
                                lblChecklistComplete.Visible = true;
                                lblChecklistComplete.Text = $"  {LanguageManager.Translate("completion_label")}:  {completionPercentage}%";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboChecklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChecklist.SelectedItem == null)
            {
                MessageBox.Show("Please select a checklist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedChecklistID = cmbChecklist.SelectedItem.ToString();
            DateTime startDate = isAllTime ? new DateTime(1753, 1, 1) : dtpStartDate.Value.Date;
            DateTime endDate = isAllTime ? DateTime.MaxValue : dtpEndDate.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = Program.connectionString;
            string query = @"
                SELECT ItemID, TaskDescription, IsCompleted, CreateDate, DueDate
                FROM ChecklistItem
                WHERE ChecklistID = @ChecklistID
                AND DueDate BETWEEN @StartDate AND @EndDate";

            if (!UserSession.IsDirector)
            {
                query += @"
                AND EXISTS (
                    SELECT 1
                    FROM Checklist
                    WHERE Checklist.ChecklistID = ChecklistItem.ChecklistID
                    AND DepartmentID = @UserDepartmentID
                )";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ChecklistID", selectedChecklistID);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    if (!UserSession.IsDirector)
                    {
                        command.Parameters.AddWithValue("@UserDepartmentID", UserSession.DepartmentID);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvChecklist.DataSource = dataTable;

                    if (dataTable.Rows.Count == 0)
                    {
                        return;
                    }
                }

                UpdateProgressBar(selectedChecklistID, startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            if (endDate < startDate)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadChecklistCompletionChart(startDate, endDate);
        }
        public void LoadChecklistCompletionChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                Dictionary<string, int> statusCounts = new Dictionary<string, int>
                {
                    { "Open", 0 },
                    { "In Progress", 0 },
                    { "Closed", 0 },
                    { "Complete", 0 }
                };

                int totalChecklists = 0;

                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT c.Status, COUNT(*) AS ChecklistCount
                        FROM Checklist c
                        WHERE c.CreatedDate BETWEEN @StartDate AND @EndDate";

                    if (!UserSession.IsDirector)
                    {
                        query += " AND c.DepartmentID = @UserDepartmentID";
                    }

                    query += " GROUP BY c.Status";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);

                        if (!UserSession.IsDirector)
                        {
                            command.Parameters.AddWithValue("@UserDepartmentID", UserSession.DepartmentID);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string status = reader["Status"] == DBNull.Value ? "Unknown" : reader["Status"].ToString();
                                int count = reader["ChecklistCount"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ChecklistCount"]);

                                if (statusCounts.ContainsKey(status))
                                {
                                    statusCounts[status] = count;
                                    totalChecklists += count;
                                }
                            }
                        }
                    }
                }

                Dictionary<string, double> statusPercentages = statusCounts.ToDictionary(
                    kvp => kvp.Key,
                    kvp => totalChecklists == 0 ? 0 : (kvp.Value * 100.0) / totalChecklists
                );

                chtBoard.Series.Clear();
                chtBoard.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea();
                chtBoard.ChartAreas.Add(chartArea);

                Series series = new Series
                {
                    Name = "Checklist Status %",
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    YValueType = ChartValueType.Double,
                    Color = Color.CornflowerBlue
                };

                foreach (var status in statusPercentages.Keys)
                {
                    series.Points.AddXY(status, statusPercentages[status]);
                }

                chtBoard.Series.Add(series);

                chartArea.AxisX.Title = "Status";
                chartArea.AxisX.Interval = 1;
                chartArea.AxisX.MajorGrid.Enabled = false;

                chartArea.AxisY.Title = "Percentage (%)";
                chartArea.AxisY.LabelStyle.Format = "{0}%";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            LoadChecklists(searchText);
            // Nếu không có checklist nào được chọn, đặt ProgressBar về 0
            if (cmbChecklist.SelectedItem == null || string.IsNullOrEmpty(searchText))
            {
                prbChecklist.Value = 0;
                lblChecklistComplete.Text = "Hoàn thành: 0%";
                return;
            }

            // Cập nhật ProgressBar cho checklist được chọn
            string selectedChecklistID = cmbChecklist.SelectedItem.ToString();
            DateTime startDate = isAllTime ? new DateTime(1753, 1, 1) : dtpStartDate.Value.Date;
            DateTime endDate = isAllTime ? DateTime.MaxValue : dtpEndDate.Value.Date;

            UpdateProgressBar(selectedChecklistID, startDate, endDate);
        }
        public void LoadAllChecklists()
        {
            LoadChecklists();
        }
        public void LoadChecklists(string searchText = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Program.connectionString))
                {
                    conn.Open();

                    string query = @"
                    SELECT 
                        c.ChecklistID, 
                        c.Title, 
                        c.Description, 
                        d.DepartmentName, 
                        u.FullName AS CreatedByName,
                        c.CreatedDate, 
                        c.DueDate, 
                        c.Status
                    FROM Checklist c
                    INNER JOIN Department d ON c.DepartmentID = d.DepartmentID
                    INNER JOIN [User] u ON c.CreatedByID = u.UserID
                    LEFT JOIN ChecklistItem ci ON ci.ChecklistID = c.ChecklistID";

                    if (!string.IsNullOrEmpty(searchText))
                    {
                        query += @"
                        WHERE 
                            (LOWER(c.Title) LIKE @SearchText
                             OR LOWER(u.FullName) LIKE @SearchText
                             OR LOWER(CAST(c.Description AS NVARCHAR(MAX))) LIKE @SearchText
                             OR LOWER(CAST(c.ChecklistID AS NVARCHAR)) LIKE @SearchText
                             OR LOWER(ci.ItemID) LIKE @SearchText)";
                    }

                    if (!UserSession.IsDirector)
                    {
                        query += string.IsNullOrEmpty(searchText)
                            ? " WHERE c.DepartmentID = @UserDepartmentID"
                            : " AND c.DepartmentID = @UserDepartmentID";
                    }

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchText))
                        {
                            command.Parameters.AddWithValue("@SearchText", "%" + searchText.ToLower() + "%");
                        }

                        if (!UserSession.IsDirector)
                        {
                            command.Parameters.AddWithValue("@UserDepartmentID", UserSession.DepartmentID);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvChecklist.DataSource = dt.Rows.Count > 0 ? dt : null;

                        HashSet<string> uniqueChecklistIDs = new HashSet<string>();
                        cmbChecklist.Items.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            string checklistID = row["ChecklistID"].ToString();
                            if (!uniqueChecklistIDs.Contains(checklistID))
                            {
                                uniqueChecklistIDs.Add(checklistID);
                                cmbChecklist.Items.Add(checklistID);
                            }
                        }

                        if (cmbChecklist.Items.Count > 0)
                        {
                            cmbChecklist.SelectedIndex = 0; // Chọn giá trị đầu tiên nếu có
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadChecklistDetails(string checklistID)
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;
            if (endDate < startDate)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT ItemID, TaskDescription, IsCompleted, CreateDate, DueDate 
                        FROM ChecklistItem
                        WHERE ChecklistID = @ChecklistID
                        AND DueDate BETWEEN @StartDate AND @EndDate";
                    if (!UserSession.IsDirector)
                    {
                        query += " AND EXISTS (SELECT 1 FROM Checklist WHERE ChecklistID = @ChecklistID AND DepartmentID = @UserDepartmentID)";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ChecklistID", checklistID);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable itemTable = new DataTable();
                    adapter.Fill(itemTable);

                    dgvChecklist.DataSource = itemTable;

                    if (itemTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No items meet the filter criteria.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    UpdateProgressBar(checklistID, startDate, endDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAllTime_Click(object sender, EventArgs e)
        {
            isAllTime = true;
            DateTime startDate = new DateTime(1753, 1, 1);
            DateTime endDate = DateTime.MaxValue;

            if (cmbChecklist.SelectedItem != null)
            {
                string selectedChecklistID = cmbChecklist.SelectedItem.ToString();
                LoadChecklistDetails(selectedChecklistID, startDate, endDate);
                UpdateProgressBar(selectedChecklistID, startDate, endDate);
            }
            else
            {
                LoadAllChecklists(); 
                LoadChecklistCompletionChart(startDate, endDate); 
            }
        }
        private void LoadChecklistDetails(string checklistID, DateTime startDate, DateTime endDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    string checklistItemQuery = @"
                        SELECT ItemID, TaskDescription, IsCompleted, CreateDate, DueDate 
                        FROM ChecklistItem
                        WHERE ChecklistID = @ChecklistID
                        AND DueDate BETWEEN @StartDate AND @EndDate";

                    SqlCommand command = new SqlCommand(checklistItemQuery, connection);
                    command.Parameters.AddWithValue("@ChecklistID", checklistID);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable itemTable = new DataTable();
                    adapter.Fill(itemTable);

                    dgvChecklist.DataSource = itemTable;

                    if (itemTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No items meet the filter criteria.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    UpdateProgressBar(checklistID, startDate, endDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
