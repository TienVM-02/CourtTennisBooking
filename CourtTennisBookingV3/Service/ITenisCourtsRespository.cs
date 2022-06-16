using CourtTennisBookingV3.Models;
using System.Collections.Generic;

namespace CourtTennisBookingV3.Service
{
    public interface ITenisCourtsRespository
    {
        List<TennisCourt> GetAlḷ(string search, string sortby, int page = 1);
    }
}
