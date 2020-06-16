using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulMovies.Model;

namespace RestfulMovies
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeenController : ControllerBase
    {
        private readonly MoviesContext _context;

        public SeenController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/Seen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seen>>> GetSeen()
        {
            return await _context.Seen.ToListAsync();
        }

        // GET: api/Seen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seen>> GetSeen(int id)
        {
            var seen = await _context.Seen.FindAsync(id);

            if (seen == null)
            {
                return NotFound();
            }

            return seen;
        }

        // PUT: api/Seen/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeen(int id, Seen seen)
        {
            if (id != seen.Id)
            {
                return BadRequest();
            }

            _context.Entry(seen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeenExists(id))
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

        // POST: api/Seen
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Seen>> PostSeen(Seen seen)
        {
            _context.Seen.Add(seen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeen", new { id = seen.Id }, seen);
        }

        // DELETE: api/Seen/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Seen>> DeleteSeen(int id)
        {
            var seen = await _context.Seen.FindAsync(id);
            if (seen == null)
            {
                return NotFound();
            }

            _context.Seen.Remove(seen);
            await _context.SaveChangesAsync();

            return seen;
        }

        private bool SeenExists(int id)
        {
            return _context.Seen.Any(e => e.Id == id);
        }
    }
}
