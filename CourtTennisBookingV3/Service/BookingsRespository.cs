using CourtTennisBookingV3.Models;
using System.Collections.Generic;
using System.Linq;

namespace CourtTennisBookingV3.Service
{
    public class BookingsRespository : IBookingsRespository
    {
        private readonly TennisBooking_v1Context _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public BookingsRespository(TennisBooking_v1Context context)
        {
            _context = context;
        }

        List<Booking> IBookingsRespository.GetAlḷ(string search, string sortby, int page = 1)
        {
            var allBooking = _context.Bookings.AsQueryable();

            //search
            if (!string.IsNullOrEmpty(search))
            {
                allBooking = allBooking.Where(acc => acc.CusName.Contains(search));
            }

            allBooking = allBooking.OrderBy(acc => acc.CusName);
            if (!string.IsNullOrEmpty(sortby))
            {
                switch (sortby)
                {
                    case "Email_desc": allBooking = allBooking.OrderByDescending(acc => acc.CusName); break;
                }
            }
            //sort by name 
            var result = allBooking.Select(book => new Booking
            {
                Id = book.Id,
                CusName = book.CusName,
                CusId = book.CusId,
                CreateDate = book.CreateDate,
                TimeStart = book.TimeStart,
                TimeEnd = book.TimeEnd,
                Price = book.Price,
                CourtId = book.CourtId,
                BookingDate = book.BookingDate,
                Status = book.Status
            });

            return result.ToList();
        }
    }
}
