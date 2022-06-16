using CourtTennisBookingV3.Models;
using System.Collections.Generic;
using System.Linq;

namespace CourtTennisBookingV3.Service
{
    public class AccountRespository : IAccountRespository
    {
        private readonly TennisBooking_v2Context _context;
        public static int PAGE_SIZE { get; set; } = 5;
        public AccountRespository(TennisBooking_v2Context context)
        {
            _context = context;
        }

        List<Account> IAccountRespository.GetAlḷ(string search, string sortby, int page = 1)
        {
            var allAccount = _context.Accounts.AsQueryable();

            //search
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

            //sort by name 
            var result = allAccount.Select(acc => new Account
            {
                Email = acc.Email,
                Password = acc.Password,
                RoleId = acc.RoleId
            });

            return result.ToList();
        }


    }
}
