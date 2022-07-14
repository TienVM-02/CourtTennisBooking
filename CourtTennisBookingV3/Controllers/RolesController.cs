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
using CourtTennisBookingV3.General;
using Microsoft.AspNetCore.Authorization;

namespace CourtTennisBookingV3.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    //[Authorize]

    public class RolesController : ControllerBase
    {
        private readonly TennisBooking_v1Context _context;
        private readonly IRoleRepository _roleRepository;
        public RolesController(TennisBooking_v1Context context, IRoleRepository roleRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// Get list Roles                                                                                                                           
        /// </summary>
        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles(string search, string sortby, int page = 1)
        {
            try
            {
                var result = _roleRepository.GetAlḷ(search, sortby, page);
                var account = await (from role in _context.Roles
                                     select new
                                     {
                                         role.RoleId,
                                         role.Name,
                                     }
                                    ).ToListAsync();

                return Ok(new { StatusCode = 200, message = "The request was successfully completed", data = result });


            }
            catch (Exception)
            {

                return BadRequest("We  can't not  get account");
            }
        }



        // PUT: api/Roles/5
        /// <summary>
        /// Edit a Roles                                                                                                                           
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(string id, Role role)
        {
            try
            {
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasNumber = new Regex(@"[0-9]+");
                var hasSymbols = new Regex(@"[!@#$`%^&*()_+=\[{\]};:<>|./?,-]");
                var isPhone = new Regex(@"(0[2|1|3|5|7|8|9])+([0-9]{8})\b");
                var regexName = new Regex("^[a-zA-Z ]*$");
                var courtOwner1 = _context.CourtOwners.Find(id);
                try
                {
                    var role1 = _context.Roles.Find(id);
                    if (!RoleExists(role.RoleId = id))
                    {
                        return BadRequest(new { StatusCodes = 404, Message = " Id not found!" });
                    }
                    if (!regexName.IsMatch(role1.Name = role.Name))
                    {
                        return BadRequest(new { StatusCode = 400, Message = "Invalid Name" });
                    }
                    else
                    {
                        await _context.SaveChangesAsync();
                        return Ok(new { status = 200, message = "Update Roles successful!" });
                    }
                }
                catch (Exception e)
                {
                    return StatusCode(409, new { StatusCode = 409, Message = e.Message });
                }
            }
            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, Message = e.Message });
            }
        }

        // POST: api/Roles23754
        /// <summary>
        /// Create list Roles                                                                                                                           
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            try
            {
                var role1 = new Role();
                var regexName = new Regex("^[a-zA-Z ]*$");

                if (!regexName.IsMatch(role1.Name = role.Name))
                {
                    return BadRequest(new { StatusCode = 400, Message = "Invalid Name" });
                }
                else
                {
                    _context.Roles.Add(role);
                    await _context.SaveChangesAsync();
                    return Ok(new { status = 200, message = "Create Roles successful!" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, Message = e.Message });
            }
        }

        // DELETE: api/Roles/5
        /// <summary>
        /// Delete a Roles                                                                                                                           
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(string id)
        {
            return _context.Roles.Any(e => e.RoleId == id);
        }
    }
}
