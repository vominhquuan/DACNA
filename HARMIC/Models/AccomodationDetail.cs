using System;
using System.Collections.Generic;

#nullable disable

namespace HARMIC.Models
{
    public partial class AccomodationDetail
    {
        public int DetailId { get; set; }
        public string RoomName { get; set; }
        public string RoomNumber { get; set; }
        public decimal RoomPrice { get; set; }
        public int? RoomCapacity { get; set; }
        public string RoomStatus { get; set; }
        public string Description { get; set; }

        public virtual Accomodation Detail { get; set; }
    }
}
