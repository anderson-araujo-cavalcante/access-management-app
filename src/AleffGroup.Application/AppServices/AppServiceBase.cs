using AleffGroup.Application.Interfaces;
using AleffGroup.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace AleffGroup.Application.AppServices
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;
        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase ?? throw new ArgumentNullException(nameof(serviceBase));
        }
        public void Add(TEntity entity)
        {
            _serviceBase.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _serviceBase.Remove(entity);
        }

        public void Remove(int id)
        {
            _serviceBase.Remove(id);
        }

        public void Update(TEntity entity)
        {
            _serviceBase.Update(entity);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
