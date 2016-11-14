using System;
using System.Collections.Generic;
using Bigly.Infrastructure.DomainBase;

namespace Bigly.Infrastructure
{
    public interface IRepository<TEntity> where TEntity: class, IAggregateRoot
    {
        IContext<TEntity> Dal { get; set; }
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        bool DeleteById(int id);
    }
}
