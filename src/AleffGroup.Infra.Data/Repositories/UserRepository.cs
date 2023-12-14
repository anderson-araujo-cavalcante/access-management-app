using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Interfaces.Repositories;
using AleffGroup.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AleffGroup.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User, int>, IUserRepository
    {
        public override void Add(User entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string procedure = "proc_users_insert_into";
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@name", entity.Name);
                cmd.Parameters.AddWithValue("@login", entity.Login);
                cmd.Parameters.AddWithValue("@senha", entity.Senha);
                cmd.Parameters.AddWithValue("@is_admin", entity.IsAdmin);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override IEnumerable<User> GetAll()
        {
            string sql = "SELECT UserId, Name, Login, Senha, IsAdmin FROM User ORDER BY Name";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<User> list = new List<User>();
                User user = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            user = new User();
                            user.UserId = (int)reader["UserId"]; // validar se é nulo
                            user.Name = reader["Name"].ToString();
                            user.Login = reader["Login"].ToString();
                            user.Senha = reader["Senha"].ToString(); // retirar ou ajustar
                            user.IsAdmin = (bool)reader["IsAdmin"];
                            list.Add(user);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return list;
            }
        }

        public override User GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "SELECT UserId, Name, Login, Senha, IsAdmin FROM User WHERE UserId=@UserId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UserId", id);
                User user = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                user = new User();
                                user.UserId = (int)reader["UserId"]; // validar se é nulo
                                user.Name = reader["Name"].ToString();
                                user.Login = reader["Login"].ToString();
                                user.Senha = reader["Senha"].ToString(); // retirar ou ajustar
                                user.IsAdmin = (bool)reader["IsAdmin"];
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return user;
            }
        }

        public override void Remove(User entity)
        {
            Remove(entity.UserId);
        }

        public override void Remove(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE User Where UserId=@userId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override void Update(User entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE User SET Name=@name, Login=@login, Senha=@senha, IsAdmin=@is_admin Where UserId=@userId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", entity.UserId);
                cmd.Parameters.AddWithValue("@name", entity.Name);
                cmd.Parameters.AddWithValue("@login", entity.Login);
                cmd.Parameters.AddWithValue("@senha", entity.Senha);
                cmd.Parameters.AddWithValue("@is_admin", entity.IsAdmin);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
