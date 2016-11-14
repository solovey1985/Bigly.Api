using System;

namespace Driveme.Core.Services.Services
{
    public abstract class BaseService<T>:IDisposable where T:class
    {
        
        
        protected BaseService()
        {
            
        }
        

        #region DISPOSING

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            
        }

        #endregion

    }
}
