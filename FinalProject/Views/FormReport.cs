using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Image = System.Drawing.Image;
using Font = System.Drawing.Font;
using System.Xml.Linq;
using Guna.UI2.WinForms.Suite;
using System.Runtime.InteropServices.ComTypes;
using OfficeOpenXml;
using FinalProject.Models;

namespace FinalProject.Views
{
    public partial class FormReport : Form, ILocalizable
    {
        public FormReport()
        {
            InitializeComponent();
            ApplyLanguage();
        }
        public void ApplyLanguage()
        {
            lblReport.Text = LanguageManager.Translate("report");
            btnExport.Text = LanguageManager.Translate("exportp");
            lblStauts.Text = LanguageManager.Translate("status");
            btnAll.Text = LanguageManager.Translate("all");
            btnOpen.Text = LanguageManager.Translate("open");
            btnInprogress.Text = LanguageManager.Translate("inprogress");
            btnComplete.Text = LanguageManager.Translate("complete");
            btnClosed.Text = LanguageManager.Translate("closed");
            lblDepartment.Text = LanguageManager.Translate("department");
            lblFilter.Text = LanguageManager.Translate("filter");
            btnAllTime.Text = LanguageManager.Translate("btnAllTime");
            btnExportExcel.Text = LanguageManager.Translate("exporte");

            lblChecklistComplete.Text = string.Empty; // Ban đầu để trống
            lblChecklistComplete.Visible = false; // Ẩn nhãn cho đến khi có thao tác
        }

        private DataTable originalDataTable;
        private void Report_Load(object sender, EventArgs e)
        {
            LoadChecklistIDs();
            btnAll.Click += btnAll_Click;
            btnOpen.Click += btnOpen_Click;
            btnComplete.Click += btnComplete_Click;
            btnInprogress.Click += btnInprogress_Click;
            btnClosed.Click += btnClosed_Click;
            btnAll.Click += (s, args) => UpdateButtonColors_1(btnAll);
            btnOpen.Click += (s, args) => UpdateButtonColors_1(btnOpen);
            btnComplete.Click += (s, args) => UpdateButtonColors_1(btnComplete);
            btnInprogress.Click += (s, args) => UpdateButtonColors_1(btnInprogress);
            btnClosed.Click += (s, args) => UpdateButtonColors_1(btnClosed);
            ApplyLanguage();
        }
        public void UpdateProgressBar(string departmentID, DateTime startDate, DateTime endDate)
        {
            if (!UserSession.IsDirector  && UserSession.DepartmentID != departmentID)
            {
                MessageBox.Show("You do not have permission to view data for this department.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                connection.Open();
                string query = @"
                SELECT 
                    SUM(CAST(ci.IsCompleted AS INT)) AS CompletedItems, 
                    COUNT(ci.ItemID) AS TotalItems
                FROM ChecklistItem ci
                JOIN Checklist c ON ci.ChecklistID = c.ChecklistID
                WHERE 1 = 1";

                if (!string.IsNullOrEmpty(departmentID))
                {
                    query += " AND c.DepartmentID = @DepartmentID";
                }

                if (startDate != DateTime.MinValue && endDate != DateTime.MaxValue)
                {
                    query += " AND ci.CreateDate BETWEEN @StartDate AND @EndDate";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(departmentID))
                    {
                        command.Parameters.AddWithValue("@DepartmentID", departmentID);
                    }

                    if (startDate != DateTime.MinValue && endDate != DateTime.MaxValue)
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string totalItems = reader["TotalItems"] != DBNull.Value ? reader["TotalItems"].ToString() : "0";
                            string completedItems = reader["CompletedItems"] != DBNull.Value ? reader["CompletedItems"].ToString() : "0";

                            int total = Convert.ToInt32(totalItems);
                            int completed = Convert.ToInt32(completedItems);
                            int completionPercentage = (total == 0) ? 0 : (completed * 100) / total;

                            prbChecklist.Value = completionPercentage;

                            // Hiển thị nhãn và cập nhật văn bản theo ngôn ngữ
                            lblChecklistComplete.Visible = true;
                            lblChecklistComplete.Text = $"  {LanguageManager.Translate("completion_label")}:  {completionPercentage}%";
                        }
                    }
                }
            }
        }
        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedItem == null)
            {
                MessageBox.Show("Please select a department.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedDepartmentID = ((KeyValuePair<string, string>)cmbDepartment.SelectedItem).Key;
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;
            if (!UserSession.IsDirector && !UserSession.UserID.StartsWith("DIRE") && selectedDepartmentID != UserSession.DepartmentID)
            {
                MessageBox.Show("You do not have permission to view data for this department.");
                return;
            }

            LoadDepartmentData(startDate, endDate, selectedDepartmentID == "All Departments" ? null : selectedDepartmentID);
            UpdateProgressBar(selectedDepartmentID, startDate, endDate);
        }

        private void LoadChecklistIDs()
        {
            string connectionString = Program.connectionString;
            string query = "SELECT DepartmentID, DepartmentName FROM Department";
            if (!UserSession.IsDirector)
            {
                query = "SELECT DepartmentID, DepartmentName FROM Department WHERE DepartmentID = @UserDepartmentID";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    if (!UserSession.IsDirector)
                    {
                        command.Parameters.AddWithValue("@UserDepartmentID", UserSession.DepartmentID);
                    }
                    SqlDataReader reader = command.ExecuteReader();

                    Dictionary<string, string> departments = new Dictionary<string, string>();
                    if (UserSession.IsDirector)
                    {
                        departments.Add("", "All Departments");
                    }

                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0)) 
                        {
                            string departmentID = reader.GetString(0); 
                            string departmentName = reader.GetString(1); 
                            departments.Add(departmentID, departmentName);
                        }
                        else
                        {
                            Console.WriteLine("DepartmentID is NULL for one row.");
                        }
                    }

                    cmbDepartment.DataSource = new BindingSource(departments, null);
                    cmbDepartment.DisplayMember = "Value"; 
                    cmbDepartment.ValueMember = "Key";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAllTime_Click(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedItem == null)
            {
                MessageBox.Show("Please select a department.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedDepartmentID = ((KeyValuePair<string, string>)cmbDepartment.SelectedItem).Key;
            if (!UserSession.IsDirector && selectedDepartmentID != UserSession.DepartmentID)
            {
                MessageBox.Show("You do not have permission to view data for this department.");
                return;
            }

            DateTime startDate = new DateTime(2000, 1, 1);
            DateTime endDate = DateTime.Today;
            dtpStartDate.Value = startDate;
            dtpEndDate.Value = endDate;

            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    string query = @"
                    SELECT 
                        ci.ItemID, 
                        c.ChecklistID, 
                        ci.TaskDescription, 
                        CONCAT(TRIM(ci.ItemID), ' - ', ci.TaskDescription) AS ItemTask,
                        ci.IsCompleted, 
                        ci.CreateDate AS ItemCreateDate, 
                        ci.DueDate AS ItemDueDate,
                        CONCAT(TRIM(c.ChecklistID), ' - ', c.Title) AS ChecklistInfo,
                        c.Description AS ChecklistDescription,
                        c.Status,
                        CONCAT(TRIM(e.EmployeeID), ' - ', e.Name) AS EmployeeInfo,
                        c.DepartmentID
                    FROM ChecklistItem ci
                    LEFT JOIN Checklist c ON ci.ChecklistID = c.ChecklistID
                    LEFT JOIN Employee e ON ci.EmployeeID = e.EmployeeID
                    INNER JOIN Department d ON c.DepartmentID = d.DepartmentID
                    WHERE c.DepartmentID = @DepartmentID
                        AND ci.CreateDate BETWEEN @StartDate AND @EndDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DepartmentID", selectedDepartmentID);
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);

                        DataTable dataTable = new DataTable();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        dgvChecklist.DataSource = null;
                        dgvChecklist.DataSource = dataTable;

                        ConfigureDataGridViewColumns();
                    }
                }

                UpdateProgressBar(selectedDepartmentID, DateTime.MinValue, DateTime.MaxValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigureDataGridViewColumns()
        {
            if (dgvChecklist.Columns.Count == 0) return;

            dgvChecklist.Columns["ItemTask"].HeaderText = "Item - Task Description";
            dgvChecklist.Columns["ChecklistInfo"].HeaderText = "Checklist - Title";
            dgvChecklist.Columns["EmployeeInfo"].HeaderText = "Employee (ID - Name)";
            dgvChecklist.Columns["ItemCreateDate"].HeaderText = "Create Date";
            dgvChecklist.Columns["ItemDueDate"].HeaderText = "Due Date";
            dgvChecklist.Columns["Status"].HeaderText = "Status";
            dgvChecklist.Columns["IsCompleted"].HeaderText = "Completed";

            dgvChecklist.Columns["ItemTask"].DisplayIndex = 0;
            dgvChecklist.Columns["ChecklistInfo"].DisplayIndex = 1;
            dgvChecklist.Columns["EmployeeInfo"].DisplayIndex = 2;
            dgvChecklist.Columns["ItemCreateDate"].DisplayIndex = 3;
            dgvChecklist.Columns["ItemDueDate"].DisplayIndex = 4;
            dgvChecklist.Columns["Status"].DisplayIndex = 5;
            dgvChecklist.Columns["IsCompleted"].DisplayIndex = 6;

            dgvChecklist.Columns["ItemID"].Visible = false;
            dgvChecklist.Columns["ChecklistID"].Visible = false;
            dgvChecklist.Columns["TaskDescription"].Visible = false;
            dgvChecklist.Columns["ChecklistDescription"].Visible = false;
            dgvChecklist.Columns["DepartmentID"].Visible = false;
        }
        private void UpdateButtonColors_1(Guna.UI2.WinForms.Guna2Button selectedButton)
        {
            foreach (Control control in selectedButton.Parent.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2Button button &&
                    (button == btnAll || button == btnOpen || button == btnComplete || button == btnInprogress || button == btnClosed))
                {
                    button.FillColor = Color.Transparent;
                    button.ForeColor = Color.Black;
                }
            }

            selectedButton.FillColor = Color.FromArgb(3, 76, 172);
            selectedButton.ForeColor = Color.White;
        }
        private void FilterDataGridView(string status, DateTime startDate, DateTime endDate)
        {
            if (originalDataTable == null) return;

            DataView dataView = new DataView(originalDataTable);

            string filterCondition = $"ItemCreateDate >= #{startDate:yyyy-MM-dd}# AND ItemCreateDate <= #{endDate:yyyy-MM-dd}#";

            if (status != "All")
            {
                filterCondition += $" AND Status = '{status}'";
            }

            string selectedDepartmentID = ((KeyValuePair<string, string>)cmbDepartment.SelectedItem).Key;
            if (!string.IsNullOrEmpty(selectedDepartmentID) && selectedDepartmentID != "All Departments")
            {
                filterCondition += $" AND DepartmentID = '{selectedDepartmentID}'";
            }
            else if (!UserSession.IsDirector)
            {
                filterCondition += $" AND DepartmentID = '{UserSession.DepartmentID}'";
            }

            try
            {
                dataView.RowFilter = filterCondition;
                dgvChecklist.DataSource = dataView.Count > 0 ? dataView.ToTable() : null;
                ConfigureDataGridViewColumns();

                if (dataView.Count == 0)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while filtering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDepartmentData(DateTime startDate, DateTime endDate, string departmentID = null)
        {
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
                        SELECT 
                            ci.ItemID, 
                            c.ChecklistID, 
                            ci.TaskDescription, 
                            CONCAT(TRIM(ci.ItemID), ' - ', ci.TaskDescription) AS ItemTask,
                            ci.IsCompleted, 
                            ci.CreateDate AS ItemCreateDate, 
                            ci.DueDate AS ItemDueDate,
                            CONCAT(TRIM(c.ChecklistID), ' - ', c.Title) AS ChecklistInfo,
                            c.Description AS ChecklistDescription,
                            c.Status,
                            CONCAT(TRIM(e.EmployeeID), ' - ', e.Name) AS EmployeeInfo,
                            c.DepartmentID
                        FROM ChecklistItem ci
                        LEFT JOIN Checklist c ON ci.ChecklistID = c.ChecklistID
                        LEFT JOIN Employee e ON ci.EmployeeID = e.EmployeeID
                        INNER JOIN Department d ON c.DepartmentID = d.DepartmentID
                        WHERE ci.CreateDate BETWEEN @StartDate AND @EndDate";

                    if (!string.IsNullOrEmpty(departmentID))
                    {
                        query += " AND c.DepartmentID = @DepartmentID";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);

                        if (!string.IsNullOrEmpty(departmentID))
                        {
                            command.Parameters.AddWithValue("@DepartmentID", departmentID);
                        }

                        DataTable dataTable = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        originalDataTable = dataTable;
                        dgvChecklist.DataSource = originalDataTable;
                        ConfigureDataGridViewColumns();
                    }
                }
                UpdateProgressBar(departmentID, startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            FilterDataGridView("All", dtpStartDate.Value.Date, dtpEndDate.Value.Date);
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            FilterDataGridView("Open", dtpStartDate.Value.Date, dtpEndDate.Value.Date);
        }
        private void btnInprogress_Click(object sender, EventArgs e)
        {
            FilterDataGridView("In Progress", dtpStartDate.Value.Date, dtpEndDate.Value.Date);
        }
        private void btnComplete_Click(object sender, EventArgs e)
        {
            FilterDataGridView("Complete", dtpStartDate.Value.Date, dtpEndDate.Value.Date);
        }
        private void btnClosed_Click(object sender, EventArgs e)
        {
            FilterDataGridView("Closed", dtpStartDate.Value.Date, dtpEndDate.Value.Date);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF file (*.pdf)|*.pdf",
                FileName = "Report.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string departmentName = cmbDepartment.Text;
                string employeeName = UserSession.FullName;
                string position = "Trưởng phòng";  // Chức vụ của người đăng nhập
                string startDate = dtpStartDate.Value.ToString("dd/MM/yyyy");  // Ngày bắt đầu
                string endDate = dtpEndDate.Value.ToString("dd/MM/yyyy");  // Ngày kết thúc
                string reportID = $"RP{new Random().Next(1, 1000):D3}";

                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 36f, 36f, 70f, 50f);
                    // Tạo đối tượng PdfPageEvents và truyền dữ liệu
                    var pageEvents = new PdfPageEvents
                    {
                        DepartmentName = departmentName, // Truyền thông tin phòng ban
                        ReportID = reportID, // Truyền ReportID cố định
                        CompanyName = "BCMP" // Tên công ty (cố định hoặc lấy từ input khác nếu cần)
                    };
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    writer.PageEvent = pageEvents;
                    pdfDoc.Open();

                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                    BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                    // Dòng đầu tiên - Tiêu đề "BÁO CÁO KẾT QUẢ CÔNG VIỆC PHÒNG"
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD);
                    pdfDoc.Add(new Paragraph("\n\n\n"));
                    Paragraph titleParagraph = new Paragraph("BÁO CÁO KẾT QUẢ CÔNG VIỆC PHÒNG", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    pdfDoc.Add(titleParagraph);

                    // Dòng thứ hai - Tên phòng ban, căn giữa
                    iTextSharp.text.Font departmentFont = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD);
                    Paragraph departmentParagraph = new Paragraph(departmentName, departmentFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    pdfDoc.Add(departmentParagraph);

                    // Thông tin người đăng nhập
                    iTextSharp.text.Font bodyFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.NORMAL);

                    // Họ và tên
                    Paragraph nameParagraph = new Paragraph($"Họ và tên: {employeeName}", bodyFont);
                    pdfDoc.Add(nameParagraph);

                    // Chức vụ
                    Paragraph positionParagraph = new Paragraph($"Chức vụ: {position}", bodyFont);
                    pdfDoc.Add(positionParagraph);

                    // Phòng ban
                    Paragraph departmentParagraph2 = new Paragraph($"Phòng ban: {departmentName}", bodyFont);
                    pdfDoc.Add(departmentParagraph2);

                    // Thời gian thực hiện
                    Paragraph timeParagraph = new Paragraph($"Thời gian thực hiện: Từ {startDate} đến {endDate}", bodyFont);
                    pdfDoc.Add(timeParagraph);
                    pdfDoc.Add(new Paragraph("\n"));
                    pdfDoc.Add(new Paragraph("\n"));

                    // **Tạo bảng tổng hợp**
                    PdfPTable summaryTable = new PdfPTable(6) { WidthPercentage = 100 };
                    summaryTable.SetWidths(new float[] { 2, 3, 1, 1, 1, 2 });

                    // Thêm tiêu đề cột
                    var summery = new string[] { "Checklist Title", "Description", "Status", "Create Date", "Due Date", "Completed (%)"};

                    // Thêm tiêu đề chỉ một lần
                    foreach (string columnName in summery)
                    {
                        string headerText = dgvChecklist.Columns[columnName]?.HeaderText ?? columnName;
                        PdfPCell headerCell = new PdfPCell(new Phrase(headerText, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)))
                        {
                            BackgroundColor = BaseColor.LIGHT_GRAY,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 5
                        };
                        summaryTable.AddCell(headerCell);
                    }

                    // Dữ liệu bảng tổng hợp
                    var summaryData = dgvChecklist.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => !row.IsNewRow)
                        .GroupBy(row => row.Cells["ChecklistInfo"].Value?.ToString())
                        .Select(group => new
                        {
                            ChecklistTitle = group.Key ?? "", // ChecklistInfo
                            Description = group.FirstOrDefault()?.Cells["ChecklistDescription"].Value?.ToString() ?? "N/A", // Thêm Description
                            CreateDate = group.FirstOrDefault()?.Cells["ItemCreateDate"].Value?.ToString() ?? "",
                            DueDate = group.FirstOrDefault()?.Cells["ItemDueDate"].Value?.ToString() ?? "",
                            CompletionPercentage = group.Count() > 0
                                ? group.Count(row => row.Cells["IsCompleted"].Value?.ToString() == "True") * 100 / group.Count()
                                : 0,
                            Status = group.FirstOrDefault()?.Cells["Status"].Value?.ToString() ?? "Unknown" // Trạng thái
                        });

                    // Thêm dữ liệu vào bảng
                    foreach (var item in summaryData)
                    {
                        summaryTable.AddCell(new Phrase(item.ChecklistTitle, FontFactory.GetFont("Arial", 10)));
                        summaryTable.AddCell(new Phrase(item.Description, FontFactory.GetFont("Arial", 10))); // Thay Description vào ManagerName
                        summaryTable.AddCell(new Phrase(item.Status, FontFactory.GetFont("Arial", 10))); // Cột trạng thái
                        summaryTable.AddCell(new Phrase(item.CreateDate, FontFactory.GetFont("Arial", 10)));
                        summaryTable.AddCell(new Phrase(item.DueDate, FontFactory.GetFont("Arial", 10)));
                        summaryTable.AddCell(new Phrase($"{item.CompletionPercentage}%", FontFactory.GetFont("Arial", 10)));
                    }

                    // Thêm bảng tổng hợp vào PDF
                    pdfDoc.Add(summaryTable);
                    pdfDoc.Add(new Paragraph("\n\n"));

                    // Các cột cần giữ lại
                    var allowedColumns = new string[] { "ItemTask", "IsCompleted", "ItemCreateDate", "ItemDueDate", "EmployeeInfo" };

                    // Group các mục theo ChecklistID
                    var groupedData = dgvChecklist.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => !row.IsNewRow) // Bỏ qua hàng trống
                        .GroupBy(row => row.Cells["ChecklistID"].Value?.ToString());


                    // Duyệt qua từng nhóm ChecklistID
                    foreach (var group in groupedData)
                    {
                        string checklistID = group.Key.Trim(); // Lấy ChecklistID
                        string checklistTitle = ""; // Lấy tiêu đề của Checklist (nếu cần từ cơ sở dữ liệu)

                        // Tạo tiêu đề cho bảng
                        Paragraph checklistTitleParagraph = new Paragraph($"Checklist: {checklistTitle} ({checklistID})", titleFont)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        pdfDoc.Add(checklistTitleParagraph);
                        pdfDoc.Add(new Paragraph("\n")); // Thêm khoảng cách

                        // Tạo bảng PDF cho ChecklistID hiện tại
                        PdfPTable checklistTable = new PdfPTable(allowedColumns.Length) { WidthPercentage = 100 };

                        // Thêm tiêu đề vào bảng
                        foreach (string columnName in allowedColumns)
                        {
                            string headerText = dgvChecklist.Columns[columnName]?.HeaderText ?? columnName;
                            PdfPCell headerCell = new PdfPCell(new Phrase(headerText, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)))
                            {
                                BackgroundColor = BaseColor.LIGHT_GRAY,
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 5
                            };
                            checklistTable.AddCell(headerCell);
                        }

                        // Thêm dữ liệu vào bảng
                        foreach (var row in group)
                        {
                            foreach (string columnName in allowedColumns)
                            {
                                string cellValue = row.Cells[columnName]?.Value?.ToString() ?? "";
                                if (columnName == "IsCompleted")
                                {
                                    cellValue = cellValue == "True" ? "Yes" : "No";
                                }
                                PdfPCell cell = new PdfPCell(new Phrase(cellValue, FontFactory.GetFont("Arial", 10)))
                                {
                                    HorizontalAlignment = Element.ALIGN_LEFT,
                                    Padding = 5
                                };
                                checklistTable.AddCell(cell);
                            }
                        }

                        // Thêm bảng vào tài liệu
                        pdfDoc.Add(checklistTable);
                        pdfDoc.Add(new Paragraph("\n\n")); // Thêm khoảng cách giữa các bảng
                    }
                    pdfDoc.Add(new Paragraph("\n\n\n"));
                    pdfDoc.Add(new Paragraph("\n\n\n"));

                    // Circular Progress Bar
                    using (Bitmap bitmap = new Bitmap(200, 250))
                    {
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit; // Làm nét văn bản
                            // Vẽ nền của vòng tròn
                            using (SolidBrush backgroundBrush = new SolidBrush(Color.LightGray))
                            {
                                g.FillEllipse(backgroundBrush, 10, 10, 180, 180); // Tăng kích thước viền
                            }
                            // Vẽ phần hoàn thành (xanh lá cây)
                            float sweepAngle = 360f * (prbChecklist.Value / 100f);
                            using (SolidBrush progressBrush = new SolidBrush(Color.Green))
                            {
                                g.FillPie(progressBrush, 10, 10, 180, 180, -90, sweepAngle); // Điều chỉnh góc quét
                            }
                            // Vẽ viền ngoài
                            using (Pen borderPen = new Pen(Color.Black, 3))
                            {
                                g.DrawEllipse(borderPen, 10, 10, 180, 180); // Vẽ viền ngoài với độ dày
                            }
                            // Vẽ text tỷ lệ hoàn thành
                            using (Font font = new Font("Arial", 18, FontStyle.Bold))
                            {
                                string percentText = $"{prbChecklist.Value}%";
                                SizeF textSize = g.MeasureString(percentText, font);
                                using (SolidBrush textBrush = new SolidBrush(Color.Black))
                                {
                                    g.DrawString(percentText, font, textBrush,
                                        bitmap.Width / 2 - textSize.Width / 2,
                                        bitmap.Height / 2 - textSize.Height / 2); // Căn giữa text
                                }
                            }

                            // Vẽ chú thích (Legend)
                            using (Font legendFont = new Font("Arial", 12, FontStyle.Bold))
                            {
                                // Kích thước và vị trí cho hình chữ nhật chú thích
                                int legendBoxWidth = 30;
                                int legendBoxHeight = 15;
                                int legendStartX = 10;
                                int legendTextOffsetX = 45;
                                int legendSpacingY = 25;

                                // Chú thích hoàn thành (Xanh)
                                g.FillRectangle(new SolidBrush(Color.Green), legendStartX, 200, legendBoxWidth, legendBoxHeight);
                                g.DrawRectangle(Pens.Black, legendStartX, 200, legendBoxWidth, legendBoxHeight); // Viền cho hình chữ nhật
                                g.DrawString(": Hoàn thành", legendFont, Brushes.Black, legendStartX + legendTextOffsetX, 198);

                                // Chú thích chưa hoàn thành (Xám)
                                g.FillRectangle(new SolidBrush(Color.Gray), legendStartX, 200 + legendSpacingY, legendBoxWidth, legendBoxHeight);
                                g.DrawRectangle(Pens.Black, legendStartX, 200 + legendSpacingY, legendBoxWidth, legendBoxHeight); // Viền cho hình chữ nhật
                                g.DrawString(": Chưa hoàn thành", legendFont, Brushes.Black, legendStartX + legendTextOffsetX, 198 + legendSpacingY);
                            }
                        }
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                            iTextSharp.text.Image progressBarImage = iTextSharp.text.Image.GetInstance(memoryStream.ToArray());
                            progressBarImage.Alignment = Element.ALIGN_CENTER;
                            pdfDoc.Add(progressBarImage);
                        }
                    }
                    pdfDoc.Close();
                    stream.Close();
                }
                MessageBox.Show("Exported successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public class PdfPageEvents : PdfPageEventHelper
        {
            private readonly iTextSharp.text.Image logo;
            private readonly BaseFont baseFont;
            public string DepartmentName { get; set; }
            public string ReportID { get; set; }
            public string CompanyName { get; set; } = "BCMP";

            private PdfTemplate totalPages; // Template để ghi tổng số trang

            public PdfPageEvents()
            {
                using (MemoryStream logoStream = new MemoryStream())
                {
                    Properties.Resources.Logo_Name_Transparent.Save(logoStream, System.Drawing.Imaging.ImageFormat.Png);
                    logo = iTextSharp.text.Image.GetInstance(logoStream.ToArray());
                    logo.ScaleToFit(50f, 50f);
                }

                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            }

            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                // Khởi tạo template để ghi tổng số trang
                totalPages = writer.DirectContent.CreateTemplate(50, 50);
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                PdfContentByte cb = writer.DirectContent;

                // Set up font for text
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                // HEADER
                float headerY = document.Top + 45; // Header nằm dưới lề trên một khoảng nhỏ
                float footerY = document.Bottom - 45;

                // Nội dung Header
                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase($"Tên BC: Báo cáo kết quả công việc", font),
                                           document.Left + 10, headerY, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase($"Số BC: {ReportID}", font), // Sử dụng ReportID cố định
                                           document.Left + 10, headerY - 12, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase($"Phòng ban: {DepartmentName}", font), // Thêm phòng ban
                                           document.Left + 10, headerY - 24, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT, new Phrase($"Công ty: {CompanyName}", font), // Thêm tên công ty
                                           document.Right - 10, headerY, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase($"Ngày tạo: {DateTime.Now:dd/MM/yyyy}", font),
                                           document.Left + 10, headerY - 36, 0);

                // Đường kẻ ngang dưới Header
                cb.MoveTo(document.Left, headerY - 40);
                cb.LineTo(document.Right, headerY - 40);
                cb.Stroke();

                // FOOTER
                // Footer separator line
                cb.MoveTo(document.Left, footerY + 26);
                cb.LineTo(document.Right, footerY + 26);
                cb.Stroke();

                // Bottom Left: Logo
                logo.SetAbsolutePosition(document.Left + 10, footerY + 5);
                cb.AddImage(logo);
                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("ver1.0", font),
                           document.Left + 10, footerY, 0);

                // Center: Page number
                int pageNumber = writer.PageNumber;
                string pageText = $"Page {pageNumber}/";

                // Đo chiều dài chuỗi "Page x/" để canh chỉnh
                float textWidth = baseFont.GetWidthPoint(pageText, 10);
                cb.BeginText();
                cb.SetFontAndSize(baseFont, 10);
                cb.SetTextMatrix((document.Left + document.Right) / 2 - textWidth / 2, footerY + 15);
                cb.ShowText(pageText);
                cb.EndText();

                // Thêm template để chèn tổng số trang sau
                cb.AddTemplate(totalPages, (document.Left + document.Right) / 2 + textWidth / 2, footerY + 15);

                // Bottom Right: Report creation timestamp
                string currentTime = $"This report was created at {DateTime.Now:dd/MM/yyyy HH:mm}";
                ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT, new Phrase(currentTime, font),
                                           document.Right - 10, footerY + 15, 0);
            }

            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                // Ghi tổng số trang vào template
                totalPages.BeginText();
                totalPages.SetFontAndSize(baseFont, 10);
                totalPages.SetTextMatrix(0, 0);
                totalPages.ShowText($"{writer.PageNumber}");
                totalPages.EndText();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvChecklist.DataSource == null)
            {
                MessageBox.Show("No data to export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";
                saveFileDialog.FileName = "ChecklistData.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    ExportToExcel(dgvChecklist, filePath);
                }
            }
        }
        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            try
            {
                OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var package = new OfficeOpenXml.ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Data");

                    // Ghi tiêu đề cột
                    for (int col = 0; col < dataGridView.Columns.Count; col++)
                    {
                        worksheet.Cells[1, col + 1].Value = dataGridView.Columns[col].HeaderText;
                    }

                    // Ghi dữ liệu
                    for (int row = 0; row < dataGridView.Rows.Count; row++)
                    {
                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            var value = dataGridView.Rows[row].Cells[col].Value;

                            // Định dạng ngày tháng cho các cột Create Date và Due Date
                            if (dataGridView.Columns[col].HeaderText == "Create Date" || dataGridView.Columns[col].HeaderText == "Due Date")
                            {
                                if (value != null)
                                {
                                    // Kiểm tra nếu là số (serial date)
                                    if (double.TryParse(value.ToString(), out double serialDate))
                                    {
                                        DateTime dateValue = DateTime.FromOADate(serialDate);
                                        worksheet.Cells[row + 2, col + 1].Value = dateValue;
                                        worksheet.Cells[row + 2, col + 1].Style.Numberformat.Format = "MM/dd/yyyy";
                                    }
                                    // Kiểm tra nếu là chuỗi ngày tháng
                                    else if (DateTime.TryParse(value.ToString(), out DateTime dateValue))
                                    {
                                        worksheet.Cells[row + 2, col + 1].Value = dateValue;
                                        worksheet.Cells[row + 2, col + 1].Style.Numberformat.Format = "MM/dd/yyyy";
                                    }
                                    else
                                    {
                                        // Nếu không phải định dạng hợp lệ, ghi trực tiếp
                                        worksheet.Cells[row + 2, col + 1].Value = value;
                                    }
                                }
                            }
                            else
                            {
                                worksheet.Cells[row + 2, col + 1].Value = value;
                            }
                        }
                    }

                    package.SaveAs(new FileInfo(filePath));
                }

                MessageBox.Show("Data exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
