using Dapper;
using DapperDBLibrary.PostgreSQL;
using System;
using System.Data;
using Xunit;

namespace DapperDBLibrary.Test
{
    public class PostgreSQLTest
    {

        private readonly IPostgreDataContext _postgreDataContext;

        public PostgreSQLTest()
        {
            _postgreDataContext = new PostgreDataContext("Host=localhost;Port=80;Pooling=true;Database=db;User Id=user;Password=123456");
        }

        [Fact]
        public void InsetClient()
        {
            var result = _postgreDataContext.Execute("insert into client values (4, 'Fulano4', '1981-07-15')", commandType: System.Data.CommandType.Text);
            Assert.True(result);
        }

        [Fact]
        public void InsetClientByProc()
        {
            var date = new DateTime(1980, 3, 15);
            var p = new DynamicParameters();
            p.Add("@_id", 13, dbType: DbType.Int32);
            p.Add("@_name", "Beltradno13", dbType: DbType.String);
            p.Add("@_birthday", date, dbType: DbType.DateTime);
            var result = _postgreDataContext.Execute("CALL insertclient(14, 'Fulano14', '1984-05-04')", CommandType.Text);
            Assert.True(result);
        }

        [Fact]
        public void GetClientById()
        {
            var result = _postgreDataContext.Execute("CALL SpGetClientById2", commandType: System.Data.CommandType.Text);
            Assert.True(result);
        }
    }
}
