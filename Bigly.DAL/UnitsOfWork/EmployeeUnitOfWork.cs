using Bigly.DAL.Contexts;

namespace Bigly.DAL.UnitsOfWork
{
    public class EmployeeUnitOfWork:UnitOfWork<EmployeeContext>
    {
        public EmployeeUnitOfWork(EmployeeContext context) : base(context)
        {
        }
    }
}
