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
    [Route("api/v1.0/[controller]")]
    [ApiController]
    //[Authorize]

    public class CustomersController : ControllerBase
    {
        private readonly TennisBooking_v1Context _context;
        private readonly ICustomerRespository _customerRespository;
        public CustomersController(TennisBooking_v1Context context, ICustomerRespository customerRespository)
        {
            _context = context;
            _customerRespository = customerRespository;
        }

        // GET: api/Customers
        /// <summary>
        /// Get list Customers                                                                                                                           
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers(string search, string sortby, int page = 1)
        {
            try
            {
                var result = _customerRespository.GetAlḷ(search, sortby, page);
                var account = await (from cus in _context.Customers
                                     select new
                                     {
                                       
                                         cus.Email,
                                         cus.FullName,
                                         cus.Dob,
                                         cus.Gender,
                                         cus.Address
                                     }
                                    ).ToListAsync();

                return Ok(new { StatusCode = 200, message = "The request was successfully completed", data = result });


            }
            catch (Exception)
            {

                return BadRequest("We  can't not  get account");
            }
        }


        /// <summary>
        /// Edit a Customers                                                                                                                           
        /// </summary>
        // PUT: api/Customers/5
        [HttpPut("{email}")]
        public async Task<IActionResult> PutCustomer(string email, Customer customer)
        {
            try
            {
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasNumber = new Regex(@"[0-9]+");
                var hasSymbols = new Regex(@"[!@#$`%^&*()_+=\[{\]};:<>|./?,-]");
                var isPhone = new Regex(@"(0[2|1|3|5|7|8|9])+([0-9]{8})\b");
                var regexName = new Regex("^[a-zA-Z ]*$");
                var courtOwner1 = _context.Customers.Find(email);
                courtOwner1.Dob = customer.Dob;
                courtOwner1.Address = customer.Address;
                if (!isPhone.IsMatch(customer.Phone))
                {
                    return BadRequest(new { StatusCode = 400, Message = "phải là số điện thoại" });
                }
                else if (!regexName.IsMatch(customer.FullName))
                {
                    return BadRequest(new { StatusCode = 400, Message = "phải là tên" });

                }
                else
                {
                    await _context.SaveChangesAsync();
                    return Ok(new { StatusCode = 200, Message = "Update Customer Successfully!" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, Message = e.Message });
            }
        }

        /// <summary>
        /// Crete a Customers                                                                                                                           
        /// </summary>
        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
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

                courtOwner1.Dob = customer.Dob;
                courtOwner1.Address = customer.Address;


                if (!isPhone.IsMatch(customer.Phone))
                {
                    return BadRequest(new { StatusCode = 400, Message = "phải là số điện thoại" });
                }
                else if (!regexName.IsMatch(customer.FullName))
                {
                    return BadRequest(new { StatusCode = 400, Message = "phải là tên" });

                }
                else if (!regexEmail.IsMatch(customer.Email))
                {
                    return BadRequest(new { StatusCode = 400, Message = "Not follow format Email" });

                }
                else
                {
                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync();
                    return Ok(new { status = 201, message = "Create Customer successfull!" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, Message = e.Message });
            }
        }

        /// <summary>
        /// Delete a Customers                                                                                                                           
        /// </summary>
        // DELETE: api/Customers/5
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(string id)
        {
            return _context.Customers.Any(e => e.Email == id);
        }
    }
}
