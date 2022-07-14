using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourtTennisBookingV3.Models;
using CourtTennisBookingV3.Service;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

namespace CourtTennisBookingV3.Controllers
{
    //[Authorize(Roles = "OC")]
    [Route("api/v1.0/[controller]")]
    [ApiController]

    public class TennisCourtsController : ControllerBase
    {
        private readonly TennisBooking_v1Context _context;
        private readonly ITenisCourtsRespository _tenisCourtsRespository;
        public TennisCourtsController(TennisBooking_v1Context context, ITenisCourtsRespository tenisCourtsRespository)
        {
            _context = context;
            _tenisCourtsRespository = tenisCourtsRespository;
        }



        /// <summary>
        /// Get list TennisCourts                                                                                                                           
        /// </summary>
        // GET: api/TennisCourts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TennisCourt>>> GetTennisCourts(string search, string sortby, int page = 1)
        {
            try
            {
                var result = _tenisCourtsRespository.GetAlḷ(search, sortby, page);
                //var account = await (from c in _context.TennisCourts
                //                     select new
                //                     {
                //                         c.Id,
                //                         c.Name,
                //                         c.Address,
                //                         c.Price,
                //                         c.OwnerId,
                //                         c.Group
                //                     }
                //                    ).ToListAsync();

                return Ok(new { StatusCode = 200, message = "The request was successfully completed", data = result });


            }
            catch (Exception)
            {

                return BadRequest("We  can't not  get account");
            }
        }

        /// <summary>
        /// Get list email ownerid                                                                                                                       
        /// </summary>
        // GET: api/TennisCourts
        [HttpGet("SearchByOwnerId")]
        public async Task<ActionResult<IEnumerable<TennisCourt>>> GetlistByOwnerId(string search)
        {
            try
            {
                var account = await (from c in _context.TennisCourts
                                     where c.OwnerId.Contains(search)
                                     select new
                                     {
                                         c.Id,
                                         c.Name,
                                         c.Address,
                                         c.Price,
                                         c.OwnerId,
                                         c.Group,
                                         c.Rating,
                                         c.Image

                                     }
                                    ).ToListAsync();

                return Ok(new { StatusCode = 200, message = "The request was successfully completed", data = account });
            }
            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, Message = e.Message });
            }
        }



        /// <summary>
        /// SearchAddress                                                                                                                           
        /// </summary>
        [HttpGet("SearchAddress")]
        public async Task<ActionResult<IEnumerable<TennisCourt>>> SearchAddress(string search)
        {
            try
            {
                var allAddress = await (from address in _context.TennisCourts
                                        where address.Address.Contains(search)
                                        select new
                                        {
                                            address.Id,
                                            address.Address,
                                            address.Name,
                                            address.OwnerId,
                                            address.Owner,
                                            address.Group,
                                            address.Price,
                                            address.Image
                                        }

                                        ).ToListAsync();
                return Ok(new { StatusCode = 200, message = "The request was successfully completed", data = allAddress });


            }
            catch (Exception e)
            {

                return StatusCode(409, new { StatusCode = 409, Message = e.Message });
            }
        }



        // PUT: api/TennisCourts/5
        /// <summary>
        /// Edit a TennisCourts                                                                                                                           
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTennisCourt(string id, TennisCourt tennisCourt)
        {
            try
            {
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasNumber = new Regex(@"[0-9]+");
                var hasSymbols = new Regex(@"[!@#$`%^&*()_+=\[{\]};:<>|./?,-]");
                var isPhone = new Regex(@"(0[2|1|3|5|7|8|9])+([0-9]{8})\b");
                var regexName = new Regex("^[0-9a-zA-Z ]*$");
                var tennisCourt1 = _context.TennisCourts.Find(id);

                var ownerID = _context.CourtOwners.FirstOrDefault(x => x.Email == tennisCourt.OwnerId);

                tennisCourt1.Address = tennisCourt.Address;
                tennisCourt1.Price = tennisCourt.Price;
                tennisCourt1.Group = tennisCourt.Group;
                tennisCourt1.Image = tennisCourt.Image;

                if (ownerID == null)
                {
                    return BadRequest(new { StatusCode = 400, Message = "CourtOwnerID ko toonf tai" });
                }
                else if (!regexName.IsMatch(tennisCourt.Name))
                {
                    return BadRequest(new { StatusCode = 400, Message = "phải là tên" });

                }
                else
                {
                    await _context.SaveChangesAsync();
                    return Ok(new { StatusCode = 200, Message = "Update Password Successfully!" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, Message = e.Message });
            }
        }

        /// <summary>
        /// Create TennisCourts                                                                                                                           
        /// </summary>
        // POST: api/TennisCourts

        [HttpPost]
        public async Task<ActionResult<TennisCourt>> PostTennisCourt(TennisCourt tennisCourt)
        {
            try
            {

                var hasLowerChar = new Regex(@"[a-z]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasNumber = new Regex(@"[0-9]+");
                var hasSymbols = new Regex(@"[!@#$`%^&*()_+=\[{\]};:<>|./?,-]");
                var isPhone = new Regex(@"(0[2|1|3|5|7|8|9])+([0-9]{8})\b");
                var regexName = new Regex("^[0-9a-zA-Z ]*$");
                var tennisCourt1 = new TennisCourt();
                tennisCourt1.Id = tennisCourt.Id;
                tennisCourt1.Address = tennisCourt.Address;
                tennisCourt1.Price = tennisCourt.Price;
                tennisCourt1.OwnerId = tennisCourt.OwnerId;
                tennisCourt1.Group = tennisCourt.Group;
                tennisCourt1.Rating = tennisCourt.Rating;
                tennisCourt1.Image = tennisCourt.Image;

                if (!regexName.IsMatch(tennisCourt1.Name = tennisCourt.Name))
                {
                    return BadRequest(new { StatusCode = 400, Message = "invalidName" });
                }
                else
                {
                    _context.TennisCourts.Add(tennisCourt1);
                    await _context.SaveChangesAsync();
                    return Ok(new { status = 201, message = "Create TennisCourts successfull!" });
                }
            }
            catch (Exception)
            {

                throw;
            }


        }



        /// <summary>
        /// Delete a TennisCourts                                                                                                                           
        /// </summary>
        // DELETE: api/TennisCourts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTennisCourt(string id)
        {
            var tennisCourt = await _context.TennisCourts.FindAsync(id);
            if (tennisCourt == null)
            {
                return NotFound();
            }

            _context.TennisCourts.Remove(tennisCourt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TennisCourtExists(string id)
        {
            return _context.TennisCourts.Any(e => e.Id == id);
        }
    }
}
