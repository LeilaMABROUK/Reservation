using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationApi.Models;

namespace ReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly Context _context;

        public ClubController(Context context)
        {
            _context = context;
        }

        // GET: api/Club
        [HttpGet]
        public IEnumerable<Club> GetClubs()
        {
            return _context.Clubs.Include(c => c.Terrains);
        }

        // GET: api/Club/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClub([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var club = await _context.Clubs.FindAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            return Ok(club);
        }

        // PUT: api/Club/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClub([FromRoute] int id, [FromBody] Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != club.IdClub)
            {
                return BadRequest();
            }

            _context.Entry(club).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(id))
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

        // POST: api/Club
        [HttpPost]
        public async Task<IActionResult> PostClub([FromBody] Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClub", new { id = club.IdClub }, club);
        }

        // DELETE: api/Club/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }

            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();

            return Ok(club);
        }

        private bool ClubExists(int id)
        {
            return _context.Clubs.Any(e => e.IdClub == id);
        }
    }
}