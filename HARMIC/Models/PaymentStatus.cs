using System;
using System.Collections.Generic;

#nullable disable

namespace HARMIC.Models
{
    public partial class PaymentStatus
    {
        public PaymentStatus()
        {
            Payments = new HashSet<Payment>();
        }

        public string PaymentStatusId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
