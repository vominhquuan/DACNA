using System;
using System.Collections.Generic;

#nullable disable

namespace HARMIC.Models
{
    public partial class Payment
    {
        public Payment()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public string PaymentId { get; set; }
        public string BookingId { get; set; }
        public DateTime? Date { get; set; }
        public string PaymentTypeId { get; set; }
        public string PaymentStatusId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
