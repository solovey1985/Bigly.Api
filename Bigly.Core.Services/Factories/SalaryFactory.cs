using Bigly.Domain.Models;

namespace Bigly.Domain.Services.Factories
{
    public interface ISalaryFactory: IBaseFactory<Salary>
    {
        
    }
    public class SalaryFactory : BaseFactory<Salary>, ISalaryFactory
    {
      
    }
}
