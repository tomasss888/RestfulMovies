using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulMovies.Model;

namespace RestfulMovies
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeržiurėtiController : ControllerBase
    {
        private readonly MoviesContext _context;

        public PeržiurėtiController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/Peržiurėti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peržiurėti>>> GetPeržiurėti()
        {
            return await _context.Peržiurėti.ToListAsync();
        }

        // GET: api/Peržiurėti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Peržiurėti>> GetPeržiurėti(int id)
        {
            var peržiurėti = await _context.Peržiurėti.FindAsync(id);

            if (peržiurėti == null)
            {
                return NotFound();
            }

            return peržiurėti;
        }

        // PUT: api/Peržiurėti/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeržiurėti(int id, Peržiurėti peržiurėti)
        {
            if (id != peržiurėti.Id)
            {
                return BadRequest();
            }

            _context.Entry(peržiurėti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeržiurėtiExists(id))
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

        // POST: api/Peržiurėti
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Peržiurėti>> PostPeržiurėti(Peržiurėti peržiurėti)
        {
            _context.Peržiurėti.Add(peržiurėti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeržiurėti", new { id = peržiurėti.Id }, peržiurėti);
        }

        // DELETE: api/Peržiurėti/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Peržiurėti>> DeletePeržiurėti(int id)
        {
            var peržiurėti = await _context.Peržiurėti.FindAsync(id);
            if (peržiurėti == null)
            {
                return NotFound();
            }

            _context.Peržiurėti.Remove(peržiurėti);
            await _context.SaveChangesAsync();

            return peržiurėti;
        }

        private bool PeržiurėtiExists(int id)
        {
            return _context.Peržiurėti.Any(e => e.Id == id);
        }
    }
}
