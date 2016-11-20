using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bigly.Api.ViewModels.Base;

namespace Bigly.Api.ViewModels
{
    public class SalaryViewModel:ViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RatePosition { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime Since { get; set; }
        public DateTime Till { get; set; }
        
    }
}
