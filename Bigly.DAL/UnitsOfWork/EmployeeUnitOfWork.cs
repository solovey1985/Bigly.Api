using Bigly.DAL.Contexts;
using Bigly.Domain.Models;
using Bigly.Infrastructure;

namespace Bigly.DAL.UnitsOfWork
{
    public interface IEmployeeUnitOfWork : IUnitOfWork<EmployeeContext>
    {
    }
    public class EmployeeUnitOfWork:UnitOfWork<EmployeeContext>, IEmployeeUnitOfWork
    {
        public EmployeeUnitOfWork(EmployeeContext context) : base(context)
        {
        }
    }

    
}
