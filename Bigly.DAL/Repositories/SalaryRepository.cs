using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Bigly.DAL.Contexts;
using Bigly.DAL.UnitsOfWork;
using Bigly.Domain.Models;
using Bigly.Infrastructure;

namespace Bigly.DAL.Repositories
{
    public interface ISalaryRepository: IRepository<Salary>
    {
        IEnumerable<Salary> GetAllWithEmployees();
    }
    public class SalaryRepository:Repository<Salary, SalaryContext>, ISalaryRepository
    {
        public SalaryRepository() : base()
        { }

        public SalaryRepository(ISalaryUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Salary> GetAllWithEmployees()
        {
            return  _dbSet.Include(s => s.Employee).ToList();
        }

        public bool BatchUpdate(List<Salary> salariesToUpdate)
        {
            if (salariesToUpdate == null && !salariesToUpdate.Any())
                return false;

            foreach (Salary model in salariesToUpdate)
            {
                if (model.Validate())
                {
                    Update(model);
                }
            }
            
            
            return true;
        }
    }

    
}
