using System;
using System.Collections.Generic;

#nullable disable

namespace HARMIC.Models
{
    public partial class Customer
    {
        public string CustomerId { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Nationality { get; set; }
        public int? IdNumber { get; set; }

        public virtual User User { get; set; }
    }
}
