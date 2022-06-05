using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourtTennisBookingv2BE.Models;

namespace CourtTennisBookingv2BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TennisCourtsController : ControllerBase
    {
        private readonly TennisBooking_v1Context _context;

        public TennisCourtsController(TennisBooking_v1Context context)
        {
            _context = context;
        }

        // GET: api/TennisCourts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TennisCourt>>> GetTennisCourts()
        {
            return await _context.TennisCourts.ToListAsync();
        }

        // GET: api/TennisCourts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TennisCourt>> GetTennisCourt(int id)
        {
            var tennisCourt = await _context.TennisCourts.FindAsync(id);

            if (tennisCourt == null)
            {
                return NotFound();
            }

            return tennisCourt;
        }

        // PUT: api/TennisCourts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTennisCourt(int id, TennisCourt tennisCourt)
        {
            if (id != tennisCourt.Id)
            {
                return BadRequest();
            }

            _context.Entry(tennisCourt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TennisCourtExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TennisCourts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TennisCourt>> PostTennisCourt(TennisCourt tennisCourt)
        {
            _context.TennisCourts.Add(tennisCourt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTennisCourt", new { id = tennisCourt.Id }, tennisCourt);
        }

        // DELETE: api/TennisCourts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTennisCourt(int id)
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

        private bool TennisCourtExists(int id)
        {
            return _context.TennisCourts.Any(e => e.Id == id);
        }
    }
}
