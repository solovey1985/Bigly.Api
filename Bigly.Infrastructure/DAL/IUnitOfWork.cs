using System;
using System.Data.Entity;

namespace Bigly.Infrastructure
{
    public interface IUnitOfWork<TContext>:IDisposable where TContext:DbContext
    {
        bool Save();
        TContext Context { get; }

    }
}
