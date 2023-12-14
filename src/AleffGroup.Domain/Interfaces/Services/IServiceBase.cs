using System.Collections.Generic;

namespace AleffGroup.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity, TKey> where TEntity : class
    {
        void Add(TEntity entity);
        TEntity GetById(TKey id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Remove(TKey id);
        void Dispose();
    }
}
