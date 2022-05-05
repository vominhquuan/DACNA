using System;
using System.Collections.Generic;

#nullable disable

namespace HARMIC.Models
{
    public partial class BookingDetail
    {
        public BookingDetail()
        {
            Bookings = new HashSet<Booking>();
        }

        public string BookingDetailId { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public int? NumberPeople { get; set; }
        public string AssignRoomId { get; set; }
        public decimal? TotalAmount { get; set; }
        public string PaymentId { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
