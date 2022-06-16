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

namespace CourtTennisBookingV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtOwnersController : ControllerBase
    {
        private readonly TennisBooking_v2Context _context;
        private readonly ICourtOwnersRespository _courtOwnersRespository;


        public CourtOwnersController(TennisBooking_v2Context context, ICourtOwnersRespository courtOwnersRespository)
        {
            _context = context;
            _courtOwnersRespository = courtOwnersRespository;
        }

        // GET: api/CourtOwners
        /// <summary>
        /// Get list CourtOwners                                                                                                                           
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourtOwner>>> GetCourtOwners(string search, string sortby, int page = 1)
        {
            try
            {
                var result = _courtOwnersRespository.GetAlḷ(search, sortby, page);
                //var account = await (from CourtOwner in _context.CourtOwners
                //                     select new
                //                     {

                //                         CourtOwner.Email,
                //                         CourtOwner.FullName,
                //                         CourtOwner.Phone,
                //                         CourtOwner.Dob,
                //                         CourtOwner.Gender,
                //                         CourtOwner.Address,
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
        /// Edit a CourtOwners                                                                                                                           
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> ChangePassword(string email, CourtOwner courtOwner)
        {
            try
            {
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasNumber = new Regex(@"[0-9]+");
                var hasSymbols = new Regex(@"[!@#$`%^&*()_+=\[{\]};:<>|./?,-]");
                var isPhone = new Regex(@"(0[2|1|3|5|7|8|9])+([0-9]{8})\b");
                var regexName = new Regex("^[a-zA-Z ]*$");
                var courtOwner1 = _context.CourtOwners.Find(email);
                courtOwner1.Dob = courtOwner.Dob;
                courtOwner1.Address = courtOwner.Address;
                if (!isPhone.IsMatch(courtOwner.Phone))
                {
                    return BadRequest(new { StatusCode = 400, Message = "phải là số điện thoại" });
                }
                else if (!regexName.IsMatch(courtOwner.FullName))
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
        /// Create a CourtOwners                                                                                                                           
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateCourtOwner( CourtOwner courtOwner)
        {
            try
            {
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasNumber = new Regex(@"[0-9]+");
                var hasSymbols = new Regex(@"[!@#$`%^&*()_+=\[{\]};:<>|./?,-]");
                var isPhone = new Regex(@"(0[2|1|3|5|7|8|9])+([0-9]{8})\b");
                var regexName = new Regex("^[a-zA-Z ]*$");
                var regexEmail = new Regex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$");
                var courtOwner1 = new CourtOwner();

                courtOwner1.Dob = courtOwner.Dob;
                courtOwner1.Address = courtOwner.Address;


                if (!isPhone.IsMatch(courtOwner.Phone))
                {
                    return BadRequest(new { StatusCode = 400, Message = "phải là số điện thoại" });
                }
                else if (!regexName.IsMatch(courtOwner.FullName))
                {
                    return BadRequest(new { StatusCode = 400, Message = "phải là tên" });

                }
                else if (!regexEmail.IsMatch(courtOwner.Email))
                {
                    return BadRequest(new { StatusCode = 400, Message = "Not follow format Email" });

                }
                else
                {
                    _context.CourtOwners.Add(courtOwner);
                    await _context.SaveChangesAsync();
                    return Ok(new { status = 201, message = "Create courtOwner successfull!" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, Message = e.Message });
            }
        }


        private bool CourtOwnerExists(string id)
        {
            return _context.CourtOwners.Any(e => e.Email == id);
        }
    }
}
