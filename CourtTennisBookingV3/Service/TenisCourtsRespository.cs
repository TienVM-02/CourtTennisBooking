using CourtTennisBookingV3.Models;
using System.Collections.Generic;
using System.Linq;

namespace CourtTennisBookingV3.Service
{
    public class TenisCourtsRespository : ITenisCourtsRespository
    {
        private readonly TennisBooking_v1Context _context;
        public static int PAGE_SIZE { get; set; } = 5;
        public TenisCourtsRespository(TennisBooking_v1Context context)
        {
            _context = context;
        }

        public List<TennisCourt> GetAlḷ(string search, string sortby, int page = 1)
        {
            var allAccount = _context.TennisCourts.AsQueryable();


            #region Fillter (search)


            if (!string.IsNullOrEmpty(search))
            {
                allAccount = allAccount.Where(acc => acc.Name.Contains(search));
            }


            allAccount = allAccount.OrderBy(acc => acc.Name);
            if (!string.IsNullOrEmpty(sortby))
            {
                switch (sortby)
                {
                    case "Email_desc": allAccount = allAccount.OrderByDescending(acc => acc.Name); break;
                }
            }

            allAccount = allAccount.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);

            #endregion

            //sort by name 
            var result = allAccount.Select(c => new TennisCourt
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Price = c.Price,
                OwnerId = c.OwnerId,
                Group = c.Group,
                Rating = c.Rating,
                Image = c.Image,
                Owner = c.Owner,

            });

            return result.ToList();
        }
    }
}
