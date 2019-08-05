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
    public class TerrainController : ControllerBase
    {
        private readonly Context _context;

        public TerrainController(Context context)
        {
            _context = context;
        }

        // GET: api/Terrain
        [HttpGet]
        public IEnumerable<Terrain> GetTerrains()
        {
            return _context.Terrains;
        }

        // GET: api/Terrain/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTerrain([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var terrain = await _context.Terrains.FindAsync(id);

            if (terrain == null)
            {
                return NotFound();
            }

            return Ok(terrain);
        }

        // PUT: api/Terrain/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTerrain([FromRoute] int id, [FromBody] Terrain terrain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != terrain.IdTerrain)
            {
                return BadRequest();
            }

            _context.Entry(terrain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerrainExists(id))
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

        // POST: api/Terrain
        [HttpPost]
        public async Task<IActionResult> PostTerrain([FromBody] Terrain terrain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Terrains.Add(terrain);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTerrain", new { id = terrain.IdTerrain }, terrain);
        }

        // DELETE: api/Terrain/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerrain([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var terrain = await _context.Terrains.FindAsync(id);
            if (terrain == null)
            {
                return NotFound();
            }

            _context.Terrains.Remove(terrain);
            await _context.SaveChangesAsync();

            return Ok(terrain);
        }

        private bool TerrainExists(int id)
        {
            return _context.Terrains.Any(e => e.IdTerrain == id);
        }
    }
}