using System;
using Bigly.Infrastructure.DomainBase;

namespace Bigly.Domain.Models
{
    public class PaymentPeriod : ValueObject<PaymentPeriod>
    {
        public DateTime Since { get; set; }

        public DateTime Till { get; set; }

        public PaymentPeriod()
        {
            
        }
        public PaymentPeriod(DateTime since, DateTime till)
        {
            Since = since;
            Till = till;
        }
        #region ValueObject
        public override bool Equals(PaymentPeriod other)
        {
            if (other == null)
            {
                return false;
            }

            return Till == other.Till && Since == other.Since;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            PaymentPeriod other = obj as PaymentPeriod;
            if (other == null)
            {
                return false;
            }

            return Equals(other);
        }

        public override int GetHashCode()
        {
            int shift = 4;

            return shift * Since.GetHashCode() * Till.GetHashCode();
        }
        #endregion
    }
}
