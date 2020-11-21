using DapperDBLibrary.Common;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DapperDBLibrary.SqLite
{
    public class SqLiteDataContext: DataContext, ISqLiteDataContext
    {
        public SqLiteDataContext(string connectionString) : base(connectionString)
        {
        }

        public SqLiteDataContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override IDbConnection DbConnection()
        {
            var db = new SqliteConnection(_connectionString);
            db.Open();
            return db;
        }
    }
}