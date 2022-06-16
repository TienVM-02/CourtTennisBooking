using CourtTennisBookingV3.Models;
using System.Collections.Generic;
using System.Linq;

namespace CourtTennisBookingV3.Service
{
    public class CourtOwnersRespository : ICourtOwnersRespository
    {
        private readonly TennisBooking_v2Context _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public CourtOwnersRespository(TennisBooking_v2Context context)
        {
            _context = context;
        }

        List<CourtOwner> ICourtOwnersRespository.GetAlḷ(string search, string sortby, int page)
        {
            var allAccount = _context.CourtOwners.AsQueryable();


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
            var result = allAccount.Select(CourtOwner => new CourtOwner
            {
                Email = CourtOwner.Email,
                FullName = CourtOwner.FullName,
                Phone = CourtOwner.Phone,
                Dob = CourtOwner.Dob,
                Gender = CourtOwner.Gender,
                Address = CourtOwner.Address,

            });

            return result.ToList();
        }
    }
}
