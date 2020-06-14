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
    public class StebėjimoSąrašasController : ControllerBase
    {
        private readonly MoviesContext _context;

        public StebėjimoSąrašasController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/StebėjimoSąrašas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StebėjimoSąrašas>>> GetStebėjimoSąrašas()
        {
            return await _context.StebėjimoSąrašas.ToListAsync();
        }

        // GET: api/StebėjimoSąrašas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StebėjimoSąrašas>> GetStebėjimoSąrašas(int id)
        {
            var stebėjimoSąrašas = await _context.StebėjimoSąrašas.FindAsync(id);

            if (stebėjimoSąrašas == null)
            {
                return NotFound();
            }

            return stebėjimoSąrašas;
        }

        // PUT: api/StebėjimoSąrašas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStebėjimoSąrašas(int id, StebėjimoSąrašas stebėjimoSąrašas)
        {
            if (id != stebėjimoSąrašas.Id)
            {
                return BadRequest();
            }

            _context.Entry(stebėjimoSąrašas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StebėjimoSąrašasExists(id))
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

        // POST: api/StebėjimoSąrašas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StebėjimoSąrašas>> PostStebėjimoSąrašas(StebėjimoSąrašas stebėjimoSąrašas)
        {
            _context.StebėjimoSąrašas.Add(stebėjimoSąrašas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStebėjimoSąrašas", new { id = stebėjimoSąrašas.Id }, stebėjimoSąrašas);
        }

        // DELETE: api/StebėjimoSąrašas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StebėjimoSąrašas>> DeleteStebėjimoSąrašas(int id)
        {
            var stebėjimoSąrašas = await _context.StebėjimoSąrašas.FindAsync(id);
            if (stebėjimoSąrašas == null)
            {
                return NotFound();
            }

            _context.StebėjimoSąrašas.Remove(stebėjimoSąrašas);
            await _context.SaveChangesAsync();

            return stebėjimoSąrašas;
        }

        private bool StebėjimoSąrašasExists(int id)
        {
            return _context.StebėjimoSąrašas.Any(e => e.Id == id);
        }
    }
}
