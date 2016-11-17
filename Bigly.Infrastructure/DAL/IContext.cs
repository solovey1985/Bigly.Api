using System;
using System.Data.Entity;

namespace Bigly.Infrastructure
{
    public interface IContext<T> : IDisposable where T : Entity
    {
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
        void SetModified(T entity);
    }
}
