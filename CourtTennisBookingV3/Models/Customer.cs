using System;
using System.Collections.Generic;

#nullable disable

namespace CourtTennisBookingV3.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }

        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
