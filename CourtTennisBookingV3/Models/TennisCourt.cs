using System;
using System.Collections.Generic;

#nullable disable

namespace CourtTennisBookingV3.Models
{
    public partial class TennisCourt
    {
        public TennisCourt()
        {
            Bookings = new HashSet<Booking>();
        }

        public string Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string OwnerId { get; set; }
        public string Group { get; set; }
        public double? Rating { get; set; }
        public string Image { get; set; }

        public virtual CourtOwner Owner { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
