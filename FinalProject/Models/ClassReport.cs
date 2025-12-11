using System;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FinalProject.Models
{
    public class ClassReport
    {
        // Các thuộc tính của class Report tương ứng với các trường trong bảng Report
        public int ReportID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string ReportType { get; set; }
        public string StatusFilter { get; set; }
        public string FooterNotes { get; set; }

        // Hàm tạo mới Report (INSERT vào cơ sở dữ liệu)
        public bool CreateReport(SqlConnection conn)
        {
            try
            {
                string query = @"
                    INSERT INTO [Report] ([ReportID], [DepartmentID], [GeneratedDate], [ReportType], [StatusFilter], [FooterNotes])
                    VALUES (@ReportID, @DepartmentID, @GeneratedDate, @ReportType, @StatusFilter, @FooterNotes)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReportID", ReportID);
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                cmd.Parameters.AddWithValue("@GeneratedDate", GeneratedDate);
                cmd.Parameters.AddWithValue("@ReportType", ReportType);
                cmd.Parameters.AddWithValue("@StatusFilter", StatusFilter);
                cmd.Parameters.AddWithValue("@FooterNotes", FooterNotes);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating report: " + ex.Message);
                return false;
            }
        }

        // Hàm xuất báo cáo ra file PDF
        public bool ExportToPDF(SqlConnection conn, string filePath)
        {
            try
            {
                // Lấy dữ liệu từ cơ sở dữ liệu
                string query = @"
                    SELECT * FROM [Report]
                    WHERE [ReportID] = @ReportID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReportID", ReportID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

                document.Open();
                if (reader.Read())
                {
                    document.Add(new Paragraph($"Report ID: {reader["ReportID"]}"));
                    document.Add(new Paragraph($"Department ID: {reader["DepartmentID"]}"));
                    document.Add(new Paragraph($"Generated Date: {reader["GeneratedDate"]}"));
                    document.Add(new Paragraph($"Report Type: {reader["ReportType"]}"));
                    document.Add(new Paragraph($"Status Filter: {reader["StatusFilter"]}"));
                    document.Add(new Paragraph($"Footer Notes: {reader["FooterNotes"]}"));
                }

                document.Close();
                conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error exporting to PDF: " + ex.Message);
                return false;
            }
        }

        // Hàm lọc báo cáo theo trạng thái
        public string FilterByStatus(SqlConnection conn, string status)
        {
            try
            {
                StringBuilder filteredReport = new StringBuilder();
                string query = @"
                    SELECT * FROM [Report]
                    WHERE [StatusFilter] = @StatusFilter";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StatusFilter", status);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    filteredReport.AppendLine($"Report ID: {reader["ReportID"]}, Status Filter: {reader["StatusFilter"]}");
                }

                conn.Close();
                return filteredReport.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error filtering by status: " + ex.Message);
                return string.Empty;
            }
        }

        // Hàm tạo báo cáo tổng hợp (Generate Report)
        public string GenerateReport(SqlConnection conn)
        {
            try
            {
                StringBuilder report = new StringBuilder();
                string query = "SELECT * FROM [Report]";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    report.AppendLine($"Report ID: {reader["ReportID"]}, Department ID: {reader["DepartmentID"]}, Generated Date: {reader["GeneratedDate"]}");
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
