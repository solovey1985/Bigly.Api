using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bigly.Domain.Models;
using Bigly.GUI.ViewModels;

namespace Bigly.Api.Services
{
    public interface ISalaryService
    {
        void BatchUpdate(List<SalaryViewModel> salariesToUpdate);
        IEnumerable<SalaryViewModel> GetPerMonthByEmloyeeId(int employeeId);
        void Update(SalaryViewModel salaryToUpdate);
        IEnumerable<SalaryViewModel> GetPerMonth();
    }
}
