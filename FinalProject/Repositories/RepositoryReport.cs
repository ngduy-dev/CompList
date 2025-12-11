using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FinalProject.Repositories
{
    internal class RepositoryReport
    {
        private readonly string connectionString = Program.connectionString;

        // Method to generate a new report
        public bool GenerateReport(string departmentID, string reportType, string statusFilter, string footerNotes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [Report] (DepartmentID, GeneratedDate, ReportType, StatusFilter, FooterNotes) " +
                               "VALUES (@DepartmentID, @GeneratedDate, @ReportType, @StatusFilter, @FooterNotes)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DepartmentID", departmentID);
                cmd.Parameters.AddWithValue("@GeneratedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ReportType", reportType);
                cmd.Parameters.AddWithValue("@StatusFilter", statusFilter);
                cmd.Parameters.AddWithValue("@FooterNotes", footerNotes);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0; // Return true if the report was successfully generated
            }
        }

        // Method to filter reports by status
        public DataTable FilterReportByStatus(string statusFilter)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [Report] WHERE StatusFilter LIKE @StatusFilter";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StatusFilter", "%" + statusFilter + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable reportTable = new DataTable();
                adapter.Fill(reportTable);

                return reportTable; // Return filtered reports
            }
        }

        // Method to export report to PDF

        // Helper method to get report data by ReportID
        private DataTable GetReportDataByReportID(int reportID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [Report] WHERE ReportID = @ReportID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReportID", reportID);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable reportTable = new DataTable();
                adapter.Fill(reportTable);

                return reportTable;
            }
        }
    }
}
