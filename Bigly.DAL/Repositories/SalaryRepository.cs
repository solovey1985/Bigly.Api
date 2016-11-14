using Bigly.DAL.Contexts;
using Bigly.DAL.UnitsOfWork;
using Bigly.Domain.Models;
using Bigly.Infrastructure;

namespace Bigly.DAL.Repositories
{
    public interface ISalaryRepository: IRepository<Salary>
    {
    }
    public class SalaryRepository:Repository<Salary, SalaryContext>, ISalaryRepository
    {
        public SalaryRepository() : base()
        { }
        public SalaryRepository(ISalaryUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }

    
}
