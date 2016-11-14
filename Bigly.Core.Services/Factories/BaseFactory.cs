using System;
using Bigly.Infrastructure;

namespace Driveme.Domain.Services.Factories
{
    public interface IBaseFactory<TEntity> where TEntity : Entity, new()
    {
        TEntity Create();
        TEntity Create(TEntity entity);
    }

    public class BaseFactory<T> : IBaseFactory<T> where T:Entity, new()
    {
       protected T entity;
        public virtual T Create()
        {
            entity = new T();
            entity.Id = 0;
            
            return entity;
        }

        public virtual T Create(T entity)
        {
            if (entity == null)
                entity = Create();
            entity.Id = 0;

            return entity; 
        }
    }
}
