using CourtTennisBookingV3.Models;
using System.Collections.Generic;

namespace CourtTennisBookingV3.Service
{
    public interface IBookingsRespository
    {
        List<Booking> GetAlḷ(string search, string sortby, int page = 1);
    }
}
