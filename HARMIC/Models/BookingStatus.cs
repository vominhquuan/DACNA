using System;
using System.Collections.Generic;

#nullable disable

namespace HARMIC.Models
{
    public partial class BookingStatus
    {
        public BookingStatus()
        {
            Bookings = new HashSet<Booking>();
        }

        public string StatusId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
