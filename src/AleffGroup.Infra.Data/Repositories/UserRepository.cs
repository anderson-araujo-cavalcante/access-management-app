using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace AleffGroup.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private const string TABLE_NAME = "Users";
        public override void Add(User entity)
        {
            string insertQuery = $@"INSERT INTO {TABLE_NAME} VALUES (@Name, @Login, @Senha, @IsAdmin)";
            Execute(entity, insertQuery);
        }

        public override IEnumerable<User> GetAll()
        {
            string sql = $"SELECT UserId, Name, Login, Senha, IsAdmin FROM {TABLE_NAME}";
            return GetAll(sql);
        }

        public override User GetById(int id)
        {
            string sql = $"SELECT UserId, Name, Login, Senha, IsAdmin FROM {TABLE_NAME} WHERE UserId = {id}";
            return Find(sql);
        }

        public override void Remove(User entity)
        {
            string sql = $"DELETE {TABLE_NAME} Where UserId=@UserId";
            Execute(entity, sql);
        }

        public override void Remove(int id)
        {
            string sql = $"DELETE {TABLE_NAME} Where UserId=@UserId";
            Execute(new User { UserId = id }, sql);
        }

        public override void Update(User entity)
        {
            string sql = $"UPDATE {TABLE_NAME} SET Name=@Name, Login=@Login, Senha=@Senha, IsAdmin=@IsAdmin Where UserId=@UserId";
            Execute(entity, sql);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
