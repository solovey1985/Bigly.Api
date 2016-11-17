using System;
using System.Collections.Generic;
using Bigly.Infrastructure.DomainBase;

namespace Bigly.Infrastructure
{
    public interface IRepository<TEntity> where TEntity: class, IAggregateRoot
    {
        
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        bool Insert(TEntity entity);
        bool BatchInsert(IEnumerable<TEntity> entities);
        bool Update(TEntity entity);
        bool BatchUpdate(IEnumerable<TEntity> entities);
        bool Delete(TEntity entity);
        bool DeleteById(int id);
    }
}
