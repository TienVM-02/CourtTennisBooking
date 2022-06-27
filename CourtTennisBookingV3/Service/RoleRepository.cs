using CourtTennisBookingV3.Models;
using System.Collections.Generic;
using System.Linq;

namespace CourtTennisBookingV3.Service
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TennisBooking_v1Context _context;
        public static int PAGE_SIZE { get; set; } = 5;
        public RoleRepository(TennisBooking_v1Context context)
        {
            _context = context;
        }

        public List<Role> GetAlḷ(string search, string sortby, int page = 1)
        {

            var allAccount = _context.Roles.AsQueryable();


            #region Fillter (search)


            if (!string.IsNullOrEmpty(search))
            {
                allAccount = allAccount.Where(acc => acc.RoleId.Contains(search));
            }


            allAccount = allAccount.OrderBy(acc => acc.RoleId);
            if (!string.IsNullOrEmpty(sortby))
            {
                switch (sortby)
                {
                    case "Email_desc": allAccount = allAccount.OrderByDescending(acc => acc.RoleId); break;
                }
            }

            allAccount = allAccount.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);

            #endregion

            //sort by name 
            var result = allAccount.Select(role => new Role
            {
                RoleId = role.RoleId,
                Name = role.Name,
            });

            return result.ToList();
        }
    }
}
