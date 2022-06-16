using CourtTennisBookingV3.Models;
using System.Collections.Generic;

namespace CourtTennisBookingV3.Service
{
    public interface ICourtOwnersRespository
    {
        List<CourtOwner> GetAlḷ(string search, string sortby, int page = 1);
    }
}
