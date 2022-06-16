using CourtTennisBookingV3.Models;
using System.Collections.Generic;
using System.Linq;

namespace CourtTennisBookingV3.Service
{
    public class CustomerRespository : ICustomerRespository
    {
        private readonly TennisBooking_v2Context _context;
        public static int PAGE_SIZE { get; set; } = 5;
        public CustomerRespository(TennisBooking_v2Context context)
        {
            _context = context;
        }
        public List<Customer> GetAlḷ(string search, string sortby, int page = 1)
        {
            var allAccount = _context.Customers.AsQueryable();


            #region Fillter (search)


            if (!string.IsNullOrEmpty(search))
            {
                allAccount = allAccount.Where(acc => acc.Email.Contains(search));
            }


            allAccount = allAccount.OrderBy(acc => acc.Email);
            if (!string.IsNullOrEmpty(sortby))
            {
                switch (sortby)
                {
                    case "Email_desc": allAccount = allAccount.OrderByDescending(acc => acc.Email); break;
                }
            }

            allAccount = allAccount.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);

            #endregion

            //sort by name 
            var result = allAccount.Select(cus => new Customer
            {
                
                Email = cus.Email,
                FullName = cus.FullName,
                Dob = cus.Dob,
                Gender = cus.Gender,
                Address = cus.Address
            });

            return result.ToList();
        }
    }
}
