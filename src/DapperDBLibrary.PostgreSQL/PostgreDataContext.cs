using DapperDBLibrary.Common;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace DapperDBLibrary.PostgreSQL
{
    public class PostgreDataContext : DataContext, IPostgreDataContext
    {
        public PostgreDataContext(string connectionString) : base(connectionString)
        {
        }

        public PostgreDataContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override IDbConnection DbConnection()
        {
            var db = new NpgsqlConnection(_connectionString);
            db.Open();
            return db;
        }
    }
}
