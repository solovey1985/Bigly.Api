using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bigly.Infrastructure;
using Bigly.Infrastructure.DomainBase;

namespace Bigly.Domain.Models
{
    public class Salary : Entity, IAggregateRoot
    {
        public int EmployeeId { get; set; }

        public PaymentPeriod Period { get; set; }

        public decimal PaidAmount { get; set; }
        
        public virtual Employee Employee { get; set; }

    }
}
