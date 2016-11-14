using Bigly.Domain.Models;

namespace Driveme.Domain.Services.Factories
{
    public interface IEmpoyeeFactory:IBaseFactory<Employee> { }
    public class EmployeeFactory:BaseFactory<Employee>, IEmpoyeeFactory
    {
    }
}
