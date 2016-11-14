using Bigly.Domain.Models;

namespace Driveme.Domain.Services.Factories
{
    public interface ISalaryFactory: IBaseFactory<Salary>
    {
        
    }
    public class SalaryFactory : BaseFactory<Salary>, ISalaryFactory
    {
      
    }
}
