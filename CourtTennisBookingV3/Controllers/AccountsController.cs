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
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly TennisBooking_v1Context _context;
        private readonly IAccountRespository _accountRespository;
        public AccountsController(TennisBooking_v1Context context, IAccountRespository accountRespository)
        {
            _context = context;
            _accountRespository = accountRespository;
        }

        // GET: api/Accounts
        /// <summary>
        /// Get list account                                                                                                                                
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts(string search, string sortby, int page = 1)
        {
            try
            {
                var result = _accountRespository.GetAlḷ(search, sortby, page);
                //var account = await (from c in _context.Accounts
                //                     select new
                //                     {
                //                         c.Email,
                //                         c.RoleId,
                //                         c.Password

                //                     }
                //                    ).ToListAsync();

                return Ok(new { StatusCode = 200, message = "The request was successfully completed", data = result });
            }
            catch (Exception e)
            {

                return StatusCode(409, new { StatusCode = 409, message = e.Message });
            }
        }

        //Change Role
        // PUT: api/Accounts/5
        /// <summary>
        /// Edit an accounts by email
        /// </summary>                                                                                                                                
        [HttpPut("role/{email}")]
        public async Task<IActionResult> ChangeRole(string email, Account account)
        {
            try
            {
                var account1 = _context.Accounts.Find(email);

                var rl = _context.Roles.FirstOrDefault(s => s.RoleId == account.RoleId);
                account1.RoleId = account.RoleId;
                if (!AccountExists(account.Email = email))
                {
                    return BadRequest(new { StatusCode = 404, Message = "ID Not Found!" });
                }
                if (rl == null)
                {
                    return BadRequest(new { StatusCode = 404, Message = "Role is not found!" });

                }
                await _context.SaveChangesAsync();

                return Ok(new { status = 200, message = "Update Successful!" });
            }
            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, Message = e.Message });
            }
        }


        /// <summary>
        /// Edit an  Password                                                                                                                                
        /// </summary>
        [HttpPut("password/{email}")]
        public async Task<IActionResult> ChangePassword(string email, Account account)
        {
            try
            {
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasNumber = new Regex(@"[0-9]+");
                var hasSymbols = new Regex(@"[!@#$`%^&*()_+=\[{\]};:<>|./?,-]");
                var account1 = _context.Accounts.Find(email);

                if (!AccountExists(account.Email = email))
                {
                    return BadRequest(new { StatusCode = 404, Message = "ID Not Found!" });
                }
                if (account1.Password == account.Password)
                {
                    return BadRequest(new { StatusCode = 400, Message = "Your new password is the same with current password!" });
                }
                account1.Password = account.Password.Trim();

                if (account.Password.Length < 8 || account.Password.Length > 16)
                {
                    return BadRequest(new { StatusCode = 400, Message = "Passwrod length must be 8 - 12" });
                }
                else if (!hasLowerChar.IsMatch(account.Password))
                {
                    return BadRequest(new { StatusCode = 400, Message = "Password should contain At least one lower case letter" });
                }
                else if (!hasNumber.IsMatch(account.Password))
                {
                    return BadRequest(new { StatusCode = 400, Message = "Password should contain At least one upper case letter" });
                }
                else if (!hasNumber.IsMatch(account.Password))
                {
                    return BadRequest(new { StatusCode = 400, Message = "Password should contain At least one numeric value" });
                }
                else if (!hasSymbols.IsMatch(account.Password))
                {
                    return BadRequest(new { StatusCode = 400, Message = "Password should contain At least one special case characters" });
                }
                //else if (!Validate.isSpace(account.Password))
                //{
                //    return BadRequest(new { StatusCode = 400, Message = "Password should not space" });
                //}
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

        // POST: api/Accounts
        /// <summary>
        /// Create an  account                                                                                                                                
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {

            try
            {
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasNumber = new Regex(@"[0-9]+");
                var hasSymbols = new Regex(@"[!@#$`%^&*()_+=\[{\]};:<>|./?,-]");
                var regexEmail = new Regex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$");
                var account1 = new Account();



                account1.RoleId = account.RoleId;
                //Check roleid có tồn tại hay không
                var account2 = _context.Roles.FirstOrDefault(x => x.RoleId == account.RoleId);
                if (!regexEmail.IsMatch(account1.Email = account.Email))
                {
                    return BadRequest(new { StatusCode = 404, Message = "This email not follow format" });
                }
                //Check input roleid
                if (account2 == null)
                {
                    return BadRequest(new { StatusCode = 404, Message = "ko role này!" });
                }
                //Check input password
                //account1.Email = account.Email;
                account1.Password = account.Password;           //check độ dài 
                    if (account1.Password.Length < 8 || account1.Password.Length > 16)
                    {
                        return BadRequest(new { StatusCode = 400, Message = "Passwrod length must be 8 - 12" });
                    }
                    else if (!hasLowerChar.IsMatch(account1.Password)) // Check kí thường
                    {
                        return BadRequest(new { StatusCode = 400, Message = "Password should contain At least one lower case letter" });
                    }
                    else if (!hasUpperChar.IsMatch(account1.Password))// Check kí tự hoa
                    {
                        return BadRequest(new { StatusCode = 400, Message = "Password should contain At least one upper case letter" });
                    }
                    else if (!hasNumber.IsMatch(account1.Password)) // check số(number)
                    {
                        return BadRequest(new { StatusCode = 400, Message = "Password should contain At least one numeric value" });
                    }
                    else if (!hasSymbols.IsMatch(account1.Password)) // check kí tự đặc biệt
                    {
                        return BadRequest(new { StatusCode = 400, Message = "Password should contain At least one special case characters" });
                    }
                    else
                    {
                        _context.Accounts.Add(account);
                        await _context.SaveChangesAsync();
                        return Ok(new { status = 201, message = "Create account successfull!" });

                    }
                
                
            }

            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, Message = e.Message });
            }

        }


        // DELETE: api/Accounts/5
        /// <summary>
        /// Delete an  account                                                                                                                                
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(string id)
        {
            return _context.Accounts.Any(e => e.Email == id);
        }
    }
}
