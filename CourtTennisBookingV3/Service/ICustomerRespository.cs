using CourtTennisBookingV3.Models;
using System.Collections.Generic;

namespace CourtTennisBookingV3.Service
{
    public interface ICustomerRespository
    {
        List<Customer> GetAlḷ(string search, string sortby, int page = 1);
    }
}
