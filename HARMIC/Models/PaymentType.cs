using System;
using System.Collections.Generic;

#nullable disable

namespace HARMIC.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Payments = new HashSet<Payment>();
        }

        public string PaymentTypeId { get; set; }
        public string PaymentType1 { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
