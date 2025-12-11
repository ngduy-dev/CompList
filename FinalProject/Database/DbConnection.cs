using System;
using System.Data.SqlClient;

namespace FinalProject.Database
{
    public class DbConnection
    {
        private readonly string _connectionString;

        public DbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Phương thức để lấy kết nối SQL Server
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
