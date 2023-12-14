using AleffGroup.Domain.Interfaces.Repositories;
using AleffGroup.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace AleffGroup.Infra.Data.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IDisposable, IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        protected string StringConnection { get; } = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public RepositoryBase()
        {            
        }

        public abstract void Add(TEntity entity);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract TEntity GetById(TKey id);
        public abstract void Remove(TEntity entity);
        public abstract void Remove(TKey id);
        public abstract void Update(TEntity entity);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
