using DapperDBLibrary.Common;
using Npgsql;

namespace DapperDBLibrary.PostgreSQL
{
    public class PostgreDataContext : DataContext, IPostgreDataContext
    {
        public PostgreDataContext(string connectionString) : base(new NpgsqlConnection(connectionString))
        {
        }

        public PostgreDataContext(NpgsqlConnection npgsqlConnection) : base(npgsqlConnection)
        {
        }
    }
}
