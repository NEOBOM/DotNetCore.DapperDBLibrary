using DapperDBLibrary.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DapperDBLibrary.SqlServer
{
    public class SqlServerDataContext : DataContext, ISqlServerDataContext
    {
        public SqlServerDataContext(string connectionString) : base(connectionString)
        {
        }

        public SqlServerDataContext(IConfiguration configuration): base(configuration)
        {
        }

        protected override IDbConnection DbConnection()
        {
            var db = new SqlConnection(_connectionString);
            db.Open();
            return db;
        }
    }
}
