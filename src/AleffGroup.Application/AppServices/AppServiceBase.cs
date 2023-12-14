using System;
using System.Collections.Generic;
using System.Text;
using AleffGroup.Application.Interfaces;
using AleffGroup.Domain.Interfaces.Services;

namespace AleffGroup.Application.AppServices
{
    public class AppServiceBase<TEntity, TKey> : IDisposable, IAppServiceBase<TEntity, TKey> where TEntity : class
    {
        private readonly IServiceBase<TEntity, TKey> _serviceBase;
        public AppServiceBase(IServiceBase<TEntity, TKey> serviceBase)
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

        public TEntity GetById(TKey id)
        {
           return _serviceBase.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _serviceBase.Remove(entity);
        }

        public void Remove(TKey id)
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
