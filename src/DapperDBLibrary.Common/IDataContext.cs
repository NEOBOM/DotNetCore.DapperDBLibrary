using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DapperDBLibrary.Common
{
    public interface IDataContext
    {
        IEnumerable<T> Query<T>(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        T QuerySingle<T>(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<T> QuerySingleAsync<T>(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        bool Execute(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<bool> ExecuteAsync(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        bool ExecuteScalar(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<bool> ExecuteScalarAsync(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        bool SPExecute(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<bool> SPExecuteAsync(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null);
        int SPExecuteScalar(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<int> SPExecuteScalarAsync(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null);
    }
}
