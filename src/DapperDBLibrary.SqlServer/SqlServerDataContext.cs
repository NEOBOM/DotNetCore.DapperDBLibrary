using DapperDBLibrary.Common;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DapperDBLibrary.SqlServer
{
    public class SqlServerDataContext : DataContext, ISqlServerDataContext
    {
        private readonly string _connectionString;

        public SqlServerDataContext(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException("connectionString can´t be nul or empty.");
        }

        protected override IDbConnection DbConnection() => new SqlConnection(_connectionString);
    }
}
