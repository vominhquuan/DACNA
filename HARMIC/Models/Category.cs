using System;
using System.Collections.Generic;

#nullable disable

namespace HARMIC.Models
{
    public partial class Category
    {
        public Category()
        {
            Accomodations = new HashSet<Accomodation>();
            Bookings = new HashSet<Booking>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Accomodation> Accomodations { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
