using DapperDBLibrary.PostgreSQL;
using System;
using System.Net.Mime;
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

        //[Fact]
        //public void GetClientById()
        //{
        //    var result = _postgreDataContext.QuerySingle("select * from client where id = 1", commandType: System.Data.CommandType.Text);
        //    Assert.True(result);
        //}
    }
}
