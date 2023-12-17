using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Interfaces.Repositories;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace AleffGroup.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private const string TABLE_NAME = "Users";
        public override void Add(User entity)
        {
            string sql = "proc_users_insert_into";
            var param = new DynamicParameters();
            param.Add("@Name", value: entity.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Login", value: entity.Login, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Senha", value: entity.Senha, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@IsAdmin", value: entity.IsAdmin, dbType: DbType.String, direction: ParameterDirection.Input);

            base.ExecuteProcedure(sql, param);
        }

        public override IEnumerable<User> GetAll()
        {
            string sql = $"SELECT UserId, Name, Login, Senha, IsAdmin FROM {TABLE_NAME}";
            return base.GetAll(sql);
        }

        public override User GetById(int id)
        {
            string sql = $"SELECT UserId, Name, Login, Senha, IsAdmin FROM {TABLE_NAME} WHERE UserId = {id}";
            return base.Find(sql);
        }

        public override void Remove(User entity)
        {
            string sql = $"DELETE {TABLE_NAME} Where UserId=@UserId";
            base.ExecuteQuery(entity, sql);
        }

        public override void Remove(int id)
        {
            string sql = $"DELETE {TABLE_NAME} Where UserId=@UserId";
            base.ExecuteQuery(new User { UserId = id }, sql);
        }

        public override void Update(User entity)
        {
            string sql = $"UPDATE {TABLE_NAME} SET Name=@Name, Login=@Login, Senha=@Senha, IsAdmin=@IsAdmin Where UserId=@UserId";
            base.ExecuteQuery(entity, sql);
        }

        public User GetByUserName(string userName)
        {
            string sql = $"proc_users_selectby_login";
            var param = new DynamicParameters();
            param.Add("@Login", value: userName, dbType: DbType.String, direction: ParameterDirection.Input);

            return base.ExecuteQueryProcedure(sql, param);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
