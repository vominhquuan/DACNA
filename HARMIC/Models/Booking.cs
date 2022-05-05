using System;
using System.Collections.Generic;

#nullable disable

namespace HARMIC.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Payments = new HashSet<Payment>();
        }

        public string BookingId { get; set; }
        public int CustomerId { get; set; }
        public int CategoryId { get; set; }
        public string BookingStatusId { get; set; }
        public string BookingDetailId { get; set; }

        public virtual BookingDetail BookingDetail { get; set; }
        public virtual BookingStatus BookingStatus { get; set; }
        public virtual Category Category { get; set; }
        public virtual Account Customer { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
