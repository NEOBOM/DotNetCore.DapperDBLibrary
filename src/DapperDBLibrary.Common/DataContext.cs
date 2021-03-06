﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;

namespace DapperDBLibrary.Common
{
    public abstract class DataContext
    {
        protected abstract IDbConnection DbConnection();

        protected string _connectionString;

        public DataContext()
        {
        }

        public DataContext(IConfiguration configuration) : this(configuration.GetConnectionString("Default"))
        {
        }

        public DataContext(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException("connectionString can´t be nul or empty.");
        }

        public virtual T Get<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            using IDbConnection dbCon = DbConnection();
            return dbCon.Get<T>(parameters);
        }

        public virtual async Task<T> GetAsync<T>(object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            using IDbConnection dbCon = DbConnection();
            return await dbCon.GetAsync<T>(parameters, transaction, commandTimeout);
        }

        public virtual IEnumerable<T> GetAll<T>(IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            using IDbConnection dbCon = DbConnection();
            return dbCon.GetAll<T>(transaction, commandTimeout);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync<T>(IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            using IDbConnection dbCon = DbConnection();
            return await dbCon.GetAllAsync<T>(transaction, commandTimeout);
        }

        public virtual bool Insert<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            using IDbConnection dbCon = DbConnection();
            return dbCon.Insert<T>(entity, transaction, commandTimeout) > 0;
        }

        public virtual async Task<bool> InsertAsync<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            using IDbConnection dbCon = DbConnection();
            return await dbCon.InsertAsync<T>(entity, transaction: transaction, commandTimeout: commandTimeout) > 0;
        }

        public virtual bool Update<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            using IDbConnection dbCon = DbConnection();
            return dbCon.Update<T>(entity, transaction: transaction, commandTimeout: commandTimeout);
        }

        public virtual async Task<bool> UpdateAsync<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            using IDbConnection dbCon = DbConnection();
            return await dbCon.UpdateAsync<T>(entity, transaction: transaction, commandTimeout: commandTimeout);
        }

        public virtual IEnumerable<T> Query<T>(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using IDbConnection dbCon = DbConnection();
            return dbCon.Query<T>(sql, parameters, transaction, commandTimeout: commandTimeout, commandType: commandType);
        }

        public virtual async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using IDbConnection dbCon = DbConnection();
            return await dbCon.QueryAsync<T>(sql, parameters, transaction, commandTimeout, commandType);
        }

        public virtual T QuerySingle<T>(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using IDbConnection dbCon = DbConnection();
            return dbCon.QueryFirstOrDefault<T>(sql, parameters, transaction, commandTimeout, commandType);
        }

        public virtual async Task<T> QuerySingleAsync<T>(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using IDbConnection dbCon = DbConnection();
            return await dbCon.QueryFirstOrDefaultAsync<T>(sql, parameters, transaction, commandTimeout, commandType);
        }

        public virtual bool Execute(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using IDbConnection dbCon = DbConnection();
            return dbCon.Execute(sql, parameters, transaction, commandTimeout, commandType) > 0;
        }

        public virtual async Task<bool> ExecuteAsync(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using IDbConnection dbCon = DbConnection();
            return await dbCon.ExecuteAsync(sql, parameters, transaction, commandTimeout, commandType) > 0;
        }

        public virtual bool ExecuteScalar(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using IDbConnection dbCon = DbConnection();
            return dbCon.ExecuteScalar<bool>(sql, parameters, transaction, commandTimeout, commandType);
        }

        public virtual async Task<bool> ExecuteScalarAsync(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using IDbConnection dbCon = DbConnection();
            return await dbCon.ExecuteScalarAsync<bool>(sql, parameters, transaction, commandTimeout, commandType);
        }

        public bool SPExecute(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using IDbConnection dbCon = DbConnection();
            return dbCon.Execute(sql, parameters, transaction, commandTimeout, CommandType.StoredProcedure) > 0;
        }

        public async Task<bool> SPExecuteAsync(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using IDbConnection dbCon = DbConnection();
            return await dbCon.ExecuteAsync(sql, parameters, transaction, commandTimeout, CommandType.StoredProcedure) > 0;
        }

        public int SPExecuteScalar(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using IDbConnection dbCon = DbConnection();
            return dbCon.ExecuteScalar<int>(sql, parameters, transaction, commandTimeout, CommandType.StoredProcedure);
        }

        public async Task<int> SPExecuteScalarAsync(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using IDbConnection dbCon = DbConnection();
            return await dbCon.ExecuteScalarAsync<int>(sql, parameters, transaction, commandTimeout, CommandType.StoredProcedure);
        }
    }
}
