using System;
using System.Collections.Generic;

#nullable disable

namespace HARMIC.Models
{
    public partial class Country
    {
        public Country()
        {
            Accomodations = new HashSet<Accomodation>();
            Customers = new HashSet<Customer>();
        }

        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<Accomodation> Accomodations { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
