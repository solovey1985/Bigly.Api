using System;
using System.Data.Entity;
using System.Diagnostics;
using Bigly.Infrastructure;
using Bigly.Infrastructure.DAL;

namespace Bigly.DAL.UnitsOfWork
{
    public abstract class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : DbContext
    {

        public TContext Context => _context;
        private TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public bool Save()
        {
            try
            {
                Context.ApplyStateChanges();
                return Context.SaveChanges() > 0;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.StackTrace);
                return false;
            }
            
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
