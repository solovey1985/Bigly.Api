using Bigly.DAL.Contexts;
using Bigly.Infrastructure;

namespace Bigly.DAL.UnitsOfWork
{
    public interface ISalaryUnitOfWork:IUnitOfWork<SalaryContext>
    {
    }

    public class SalaryUnitOfWork:UnitOfWork<SalaryContext>, ISalaryUnitOfWork
    {
        public SalaryUnitOfWork(SalaryContext context) : base(context)
        {
        }
    }
}
