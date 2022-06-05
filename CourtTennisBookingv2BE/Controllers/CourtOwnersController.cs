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
    public class CourtOwnersController : ControllerBase
    {
        private readonly TennisBooking_v1Context _context;

        public CourtOwnersController(TennisBooking_v1Context context)
        {
            _context = context;
        }

        // GET: api/CourtOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourtOwner>>> GetCourtOwners()
        {
            return await _context.CourtOwners.ToListAsync();
        }

        // GET: api/CourtOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourtOwner>> GetCourtOwner(int id)
        {
            var courtOwner = await _context.CourtOwners.FindAsync(id);

            if (courtOwner == null)
            {
                return NotFound();
            }

            return courtOwner;
        }

        // PUT: api/CourtOwners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourtOwner(int id, CourtOwner courtOwner)
        {
            if (id != courtOwner.Id)
            {
                return BadRequest();
            }

            _context.Entry(courtOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourtOwnerExists(id))
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

        // POST: api/CourtOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourtOwner>> PostCourtOwner(CourtOwner courtOwner)
        {
            _context.CourtOwners.Add(courtOwner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourtOwner", new { id = courtOwner.Id }, courtOwner);
        }

        // DELETE: api/CourtOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourtOwner(int id)
        {
            var courtOwner = await _context.CourtOwners.FindAsync(id);
            if (courtOwner == null)
            {
                return NotFound();
            }

            _context.CourtOwners.Remove(courtOwner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourtOwnerExists(int id)
        {
            return _context.CourtOwners.Any(e => e.Id == id);
        }
    }
}
