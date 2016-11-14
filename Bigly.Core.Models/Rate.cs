using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bigly.Infrastructure;

namespace Bigly.Domain.Models
{
    public class Rate : Entity
    {
        public string EmployeePosition { get; set; }
        public decimal AmountPerHour { get; set; }

        public virtual ICollection<Employee> Employees { get; protected set; }

        public override bool Validate()
        {
            return AmountPerHour >= 0 && !string.IsNullOrEmpty(EmployeePosition);
        }
    }
}
