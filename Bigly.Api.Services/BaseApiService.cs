using Bigly.Infrastructure;
using Bigly.Infrastructure.DomainBase;
using Driveme.Domain.Services.Factories;

namespace Bigly.Api.Services
{
    public interface IBaseAppService
    {
    }

    public abstract class BaseApiService<T> : IBaseAppService where T:Entity, IAggregateRoot, new()
    {
        protected IBaseFactory<T> factory;
        protected IRepository<T> repository;
        protected BaseApiService() { } 
        protected BaseApiService(IBaseFactory<T> factory, IRepository<T> repository)
        {
            this.factory = factory;
            this.repository = repository;
        }
    }
}
