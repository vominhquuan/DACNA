using System;
using System.Collections.Generic;

#nullable disable

namespace HARMIC.Models
{
    public partial class Accomodation
    {
        public Accomodation()
        {
            AccomodationDetails = new HashSet<AccomodationDetail>();
        }

        public int AccomodationId { get; set; }
        public string AccomodationName { get; set; }
        public int CategoryId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? Rate { get; set; }
        public int? Utilities { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<AccomodationDetail> AccomodationDetails { get; set; }
    }
}
