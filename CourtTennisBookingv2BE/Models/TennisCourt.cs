using System;
using System.Collections.Generic;

#nullable disable

namespace CourtTennisBookingv2BE.Models
{
    public partial class TennisCourt
    {
        public TennisCourt()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Price { get; set; }
        public int? OwnerId { get; set; }
        public string Group { get; set; }

        public virtual CourtOwner Owner { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
