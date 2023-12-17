using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Interfaces.Repositories;
using Dapper;
using System.Collections.Generic;
using System.Data;
using static Dapper.SqlMapper;
using System.Data.SqlClient;

namespace AleffGroup.Infra.Data.Repositories
{
    public class LogAccessRepository : RepositoryBase<LogAccess>, ILogAccessRepository
    {
        private const string TABLE_NAME = "LogsAccess";

        public override void Add(LogAccess entity)
        {
            string insertQuery = $@"INSERT INTO {TABLE_NAME} VALUES (@UserId, @DateTimeAccess, @AdressIp)";
            base.ExecuteQuery(entity, insertQuery);
        }

        public override IEnumerable<LogAccess> GetAll()
        {
            string sql = $"SELECT LogAcessoId, UserId, DateTimeAccess, AdressIp FROM {TABLE_NAME}";
            return base.GetAll(sql);
        }

        public override LogAccess GetById(int id)
        {
            string sql = $"SELECT LogAcessoId, UserId, DateTimeAccess, AdressIp FROM {TABLE_NAME} WHERE LogAcessoId = {id}";
            return base.Find(sql);
        }

        public override void Remove(LogAccess entity)
        {
            string sql = $"DELETE {TABLE_NAME} Where LogAcessoId=@LogAcessoId";
            base.ExecuteQuery(entity, sql);
        }

        public override void Remove(int id)
        {
            string sql = $"DELETE {TABLE_NAME} Where LogAcessoId=@LogAcessoId";
            base.ExecuteQuery(new LogAccess { LogAcessoId = id }, sql);
        }

        public override void Update(LogAccess entity)
        {
            string sql = $"UPDATE {TABLE_NAME} SET UserId=@UserId, DateTimeAccess=@SateTimeAccess, AdressIp=@AdressIp Where LogAcessoId=@LogAcessoId";
            base.ExecuteQuery(entity, sql);
        }

        public IEnumerable<LogAccess> GetAllByUserId(int? userId)
        {
            var filter = userId.HasValue ? $"WHERE log.UserId = {userId.Value}" : string.Empty ;
            string sql = $"SELECT " +
                                    $"log.LogAcessoId, log.UserId, log.DateTimeAccess, log.AdressIp, u.UserId, u.Name " +
                               $"FROM {TABLE_NAME} log " +
                               $"JOIN Users u ON log.UserId = u.UserId " +
                               $"{filter} " +
                               $"ORDER BY log.DateTimeAccess";

            using (IDbConnection dbConnection = new SqlConnection(StringConnection))
            {
                dbConnection.Open();
                return dbConnection.Query<LogAccess, User, LogAccess>(sql, map: (logAccess, user) =>
                {
                    logAccess.User = user;
                    return logAccess;
                },
                splitOn: "UserId");
            }
        }
    }
}
