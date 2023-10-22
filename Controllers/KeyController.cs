using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using softhsm_csharp.Models;

namespace softhsm_csharp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class KeyController : ControllerBase
    {
        private readonly KeyContext _context;

        public KeyController(KeyContext context)
        {
            _context = context;
        }

        // GET: api/Key
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Key>>> Getkeys()
        {
            if (_context.keys == null)
            {
                return NotFound();
            }
                return await _context.keys.ToListAsync();
        }

        // GET: api/Key/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Key>> GetKey(long id)
        {
            if (_context.keys == null)
            {
                return NotFound();
            }
            var key = await _context.keys.FindAsync(id);

            if (key == null)
            {
                return NotFound();
            }

            return key;
        }

        // PUT: api/Key/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKey(long id, Key key)
        {
            if (id != key.Id)
            {
                return BadRequest();
            }

            _context.Entry(key).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyExists(id))
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

        // POST: api/Key/generate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("generate")]
        public async Task<ActionResult<Key>> PostKey(Key key)
        {
            if (_context.keys == null)
            {
                return Problem("Entity set 'KeyContext.keys'  is null.");
            }
            // TODO - Generate specified key via Services.KeyService
            _context.keys.Add(key);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKey", new { id = key.Id }, key);
        }

        // DELETE: api/Key/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKey(long id)
        {
            if (_context.keys == null)
            {
                return NotFound();
            }
            var key = await _context.keys.FindAsync(id);
            if (key == null)
            {
                return NotFound();
            }

            _context.keys.Remove(key);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KeyExists(long id)
        {
            return (_context.keys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
