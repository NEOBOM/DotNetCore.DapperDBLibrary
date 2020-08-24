using DapperDBLibrary.Common;
using System.Data.SqlClient;

namespace DapperDBLibrary.SqlServer
{
    public class SqlServerDataContext : DataContext, ISqlServerDataContext
    {
        public SqlServerDataContext(string connectionString) : base(new SqlConnection(connectionString))
        {
        }

        public SqlServerDataContext(SqlConnection sqlConnection) : base(sqlConnection)
        {
        }
    }
}
