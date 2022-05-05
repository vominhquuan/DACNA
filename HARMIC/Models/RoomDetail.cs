using System;
using System.Collections.Generic;

#nullable disable

namespace HARMIC.Models
{
    public partial class RoomDetail
    {
        public RoomDetail()
        {
            AccomodationDetails = new HashSet<AccomodationDetail>();
        }

        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public decimal? RoomPrice { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AccomodationDetail> AccomodationDetails { get; set; }
    }
}
