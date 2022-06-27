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
    public class BookingsController : ControllerBase
    {
        private readonly TennisBooking_v1Context _context;
        private readonly IBookingsRespository _bookingsRespository;


        public BookingsController(TennisBooking_v1Context context, IBookingsRespository bookingsRespository)
        {
            _context = context;
            _bookingsRespository = bookingsRespository;

        }

        // GET: api/Bookings
        /// <summary>
        /// Get list booking                                                                                                                           
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings(string search, string sortby, int page = 1)
        {
            try
            {
                var result = _bookingsRespository.GetAlḷ(search, sortby, page);
                //var booking = await (from book in _context.Bookings
                //                     select new
                //                     {
                //                         book.Id,
                //                         book.CusName,
                //                         book.BookingDate,
                //                         book.CourtId,
                //                         book.Price,
                //                         book.Slot,
                //                         book.CusId,
                //                         book.CreateDate,
                //                         book.TimeStart,
                //                         book.TimeEnd,
                //                     }
                //                    ).ToListAsync();

                return Ok(new { StatusCode = 200, message = "The request was successfully completed", data = result });


            }
            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, message = e.Message });
            }
        }

        // PUT: api/Bookings/5
        /// <summary>
        /// Edit a booking                                                                                                                           
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(string id, Booking booking)
        {
            try
            {
                //validate
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasNumber = new Regex(@"[0-9]+");
                var hasSymbols = new Regex(@"[!@#$`%^&*()_+=\[{\]};:<>|./?,-]");

                var booking1 = _context.Bookings.Find(id);



                booking1.CusId = booking.CusId;
                booking1.CreateDate = booking.CreateDate;
                booking1.TimeStart = booking.TimeStart;
                booking1.TimeEnd = booking.TimeEnd;
                booking1.Price = booking.Price;
                booking1.CourtId = booking.CourtId;
                booking1.BookingDate = booking.BookingDate;
                booking1.Status = booking.Status;
                booking1.CusName = booking.CusName;



                var checkTennisCourtID = _context.TennisCourts.FirstOrDefault(t => t.Id == booking1.CourtId);

                if (checkTennisCourtID == null)
                {
                    return BadRequest(new { StatusCode = 404, Message = "CourtID is not found!" });
                }
                var CustomerID = _context.Customers.FirstOrDefault(t => t.Email == booking1.CusId);

                if (CustomerID == null)
                {
                    return BadRequest(new { StatusCode = 404, Message = "CustomerID is not found!" });
                }
                if (!BookingExists(booking.Id = id))
                {
                    return BadRequest(new { StatusCode = 404, Message = "ID Not Found!" });
                }
                else
                {
                    await _context.SaveChangesAsync();
                    return Ok(new { StatusCode = 200, Message = "Update Booking Successfully!" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, message = e.Message });
            }
        }

        // POST: api/Bookings
        /// <summary>
        /// Create a booking                                                                                                                           
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            try
            {
                //validate
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasNumber = new Regex(@"[0-9]+");
                var hasSymbols = new Regex(@"[!@#$`%^&*()_+=\[{\]};:<>|./?,-]");


                var booking1 = new Booking();

                // truyền dư liệu vào

                booking1.CusId = booking.CusId;
                booking1.CreateDate = booking.CreateDate;
                booking1.TimeStart = booking.TimeStart;
                booking1.TimeEnd = booking.TimeEnd;
                booking1.Price = booking.Price;
                booking1.CourtId = booking.CourtId;
                booking1.BookingDate = booking.BookingDate;
                booking1.Status = booking.Status;
                booking1.CusName = booking.CusName;


                //check tồn tại
                var checkTennisCourtID = _context.TennisCourts.FirstOrDefault(t => t.Id == booking1.CourtId);

                if (checkTennisCourtID == null)
                {
                    return BadRequest(new { StatusCode = 404, Message = "CourtID is not found!" });
                }
                var CustomerID = _context.Customers.FirstOrDefault(t => t.Email == booking1.CusId);

                if (CustomerID == null)
                {
                    return BadRequest(new { StatusCode = 404, Message = "CustomerID is not found!" });
                }
                else
                {
                    _context.Bookings.Add(booking);
                    await _context.SaveChangesAsync();
                    return Ok(new { status = 201, message = "Create booking successfull!" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, message = e.Message });
            }
        }

        // DELETE: api/Bookings/5
        /// <summary>
        /// Delete a booking                                                                                                                           
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingExists(string id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
