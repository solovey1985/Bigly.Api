using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bigly.Api.ViewModels.Base;

namespace Bigly.Api.ViewModels
{
    public class EmployeeViewModel:ViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        
    }
}
