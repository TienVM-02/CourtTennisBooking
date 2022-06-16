using System;
using System.Collections.Generic;

#nullable disable

namespace CourtTennisBookingV3.Models
{
    public partial class Account
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
