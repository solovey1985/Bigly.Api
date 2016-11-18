using Bigly.Infrastructure;
using Bigly.Infrastructure.DomainBase;
using Bigly.Domain.Services.Factories;

namespace Bigly.Api.Services
{
    public interface IBaseApiService
    {
    }

    public abstract class BaseApiService<T> : IBaseApiService where T:Entity, IAggregateRoot, new()
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
