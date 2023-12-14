using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AleffGroup.Infra.Data.Repositories
{
    public class LogAccessRepository : RepositoryBase<LogAccess, int>, ILogAccessRepository
    {
        public override void Add(LogAccess entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string procedure = "INSERT INTO LogAccess (UserId, DateTimeAccess, AdressIp) VALUES (@userId, @dateTimeAccess, @adressIp)";
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@userId", entity.UserId);
                cmd.Parameters.AddWithValue("@dateTimeAccess", entity.DateTimeAccess);
                cmd.Parameters.AddWithValue("@adressIp", entity.AdressIp);
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

        public override IEnumerable<LogAccess> GetAll()
        {
            string sql = "SELECT LogAcessoId, UserId, DateTimeAccess, AdressIp FROM LogAccess ORDER BY Name";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<LogAccess> list = new List<LogAccess>();
                LogAccess log = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            log = new LogAccess();
                            log.LogAcessoId = (int)reader["LogAcessoId"];
                            log.UserId = (int)reader["UserId"];
                            log.DateTimeAccess = Convert.ToDateTime(reader["DateTimeAccess"].ToString());
                            log.AdressIp = reader["AdressIp"].ToString();
                            list.Add(log);
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

        public override LogAccess GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "SELECT LogAcessoId, UserId, DateTimeAccess, AdressIp FROM LogAccess WHERE LogAcessoId=@LogAcessoId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@LogAcessoId", id);
                LogAccess log = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                log = new LogAccess();
                                log.LogAcessoId = (int)reader["LogAcessoId"];
                                log.UserId = (int)reader["UserId"];
                                log.DateTimeAccess = Convert.ToDateTime(reader["DateTimeAccess"].ToString());
                                log.AdressIp = reader["AdressIp"].ToString();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return log;
            }
        }

        public override void Remove(LogAccess entity)
        {
            Remove(entity.UserId);
        }

        public override void Remove(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE LogAccess Where LogAcessoId=@LogAcessoId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@LogAcessoId", id);
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

        public override void Update(LogAccess entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE LogAccess SET UserId=@userId, DateTimeAccess=@dateTimeAccess, AdressIp=@adressIp Where LogAcessoId=@logAcessoId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@logAcessoId", entity.LogAcessoId);
                cmd.Parameters.AddWithValue("@userId", entity.UserId);
                cmd.Parameters.AddWithValue("@dateTimeAccess", entity.DateTimeAccess);
                cmd.Parameters.AddWithValue("@adressIp", entity.AdressIp);
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
