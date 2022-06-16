using CourtTennisBookingV3.Models;
using System.Collections.Generic;

namespace CourtTennisBookingV3.Service
{
    public interface IAccountRespository
    {
        List<Account> GetAlḷ(string search, string sortby, int page = 1);
    }
}
