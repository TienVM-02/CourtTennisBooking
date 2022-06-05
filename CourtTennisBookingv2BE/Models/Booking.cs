using System;
using System.Collections.Generic;

#nullable disable

namespace CourtTennisBookingv2BE.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        public int? CusId { get; set; }
        public DateTime? CreateDate { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeEnd { get; set; }
        public double? Price { get; set; }
        public int? CourtId { get; set; }
        public int? Slot { get; set; }
        public DateTime? BookingDate { get; set; }

        public virtual TennisCourt Court { get; set; }
        public virtual Customer Cus { get; set; }
    }
}
