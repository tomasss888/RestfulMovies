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
    public class FilmasController : ControllerBase
    {
        private readonly MoviesContext _context;

        public FilmasController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/Filmas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filmas>>> GetFilmas()
        {
            return await _context.Filmas.ToListAsync();
        }

        // GET: api/Filmas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Filmas>> GetFilmas(int id)
        {
            var filmas = await _context.Filmas.FindAsync(id);

            if (filmas == null)
            {
                return NotFound();
            }

            return filmas;
        }

        // PUT: api/Filmas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmas(int id, Filmas filmas)
        {
            if (id != filmas.Id)
            {
                return BadRequest();
            }

            _context.Entry(filmas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmasExists(id))
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

        // POST: api/Filmas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Filmas>> PostFilmas(Filmas filmas)
        {
            _context.Filmas.Add(filmas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmas", new { id = filmas.Id }, filmas);
        }

        // DELETE: api/Filmas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Filmas>> DeleteFilmas(int id)
        {
            var filmas = await _context.Filmas.FindAsync(id);
            if (filmas == null)
            {
                return NotFound();
            }

            _context.Filmas.Remove(filmas);
            await _context.SaveChangesAsync();

            return filmas;
        }

        private bool FilmasExists(int id)
        {
            return _context.Filmas.Any(e => e.Id == id);
        }
    }
}
