using CourtTennisBookingV3.Models;
using System.Collections.Generic;

namespace CourtTennisBookingV3.Service
{
    public interface IRoleRepository
    {
        List<Role> GetAlḷ(string search, string sortby, int page = 1);
    }
}
