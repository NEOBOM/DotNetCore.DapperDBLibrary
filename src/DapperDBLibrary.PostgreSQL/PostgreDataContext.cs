using DapperDBLibrary.Common;
using Npgsql;
using System;
using System.Data;

namespace DapperDBLibrary.PostgreSQL
{
    public class PostgreDataContext : DataContext, IPostgreDataContext
    {
        private readonly string _connectionString;

        public PostgreDataContext(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException("connectionString can´t be nul or empty.");
        }

        protected override IDbConnection DbConnection()
        {
            var db = new NpgsqlConnection(_connectionString);
            db.Open();
            return db;
        }
    }
}
