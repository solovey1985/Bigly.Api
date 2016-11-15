using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bigly.Api.ViewModels;

namespace Bigly.Api.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeViewModel> GetAll();
    }
}
