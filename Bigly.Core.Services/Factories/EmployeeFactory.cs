using Bigly.Domain.Models;

namespace Bigly.Domain.Services.Factories
{
    public interface IEmpoyeeFactory:IBaseFactory<Employee> { }
    public class EmployeeFactory:BaseFactory<Employee>, IEmpoyeeFactory
    {
    }
}
