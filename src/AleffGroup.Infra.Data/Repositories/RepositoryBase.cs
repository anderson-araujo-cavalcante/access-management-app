using AleffGroup.Domain.Interfaces.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static Dapper.SqlMapper;

namespace AleffGroup.Infra.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected string StringConnection { get; } = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected readonly IDbConnection connection;
        protected readonly IDbTransaction transaction;

        public abstract void Add(TEntity entity);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract TEntity GetById(int id);
        public abstract void Remove(TEntity entity);
        public abstract void Remove(int id);
        public abstract void Update(TEntity entity);

        protected IEnumerable<TEntity> GetAll(string sql)
        {
            using (IDbConnection dbConnection = new SqlConnection(StringConnection))
            {
                dbConnection.Open();
                return dbConnection.Query<TEntity>(sql);
            }
        }

        protected TEntity Find(string sql)
        {
            using (IDbConnection dbConnection = new SqlConnection(StringConnection))
            {
                dbConnection.Open();
                return dbConnection.Query<TEntity>(sql).FirstOrDefault();
            }
        }

        protected void ExecuteQuery(TEntity entity, string query)
        {
            using (IDbConnection dbConnection = new SqlConnection(StringConnection))
            {
                var result = dbConnection.Execute(query, entity);
            }
        }

        protected TEntity ExecuteQueryProcedure(string proc, DynamicParameters param)
        {
            using (IDbConnection dbConnection = new SqlConnection(StringConnection))
            {
                var user = dbConnection.QuerySingle<TEntity>(
                    proc,
                    param,
                    commandType: CommandType.StoredProcedure
                );

                return user;
            }
        }

        protected void ExecuteProcedure(string proc, DynamicParameters param)
        {
            using (IDbConnection dbConnection = new SqlConnection(StringConnection))
            {
                dbConnection.Execute(proc, param, commandType: CommandType.StoredProcedure);
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
