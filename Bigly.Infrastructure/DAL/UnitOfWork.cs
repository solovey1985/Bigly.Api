using System;
using System.Data.Entity;
using Bigly.Infrastructure;
using Bigly.Infrastructure.DAL;

namespace Bigly.DAL.UnitsOfWork
{
    public abstract class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext:DbContext
    {

        public TContext Context => _context;
        private TContext _context;
        public UnitOfWork(TContext context)
        {
            _context = context;
        } 

        public int Save()
        {
            Context.ApplyStateChanges();
            return Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
