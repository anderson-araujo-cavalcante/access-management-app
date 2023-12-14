using AleffGroup.Domain.Interfaces.Repositories;
using AleffGroup.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace AleffGroup.Domain.Services
{
    public class ServiceBase<TEntity, TKey> : IDisposable, IServiceBase<TEntity, TKey> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity, TKey> _repository;

        public ServiceBase(IRepositoryBase<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(TKey id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public void Remove(TKey id)
        {
            _repository.Remove(id);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
