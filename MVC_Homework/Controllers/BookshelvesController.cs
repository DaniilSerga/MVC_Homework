using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Homework.Models;
using MVC_Homework.Models.DatabaseModels;

namespace MVC_Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookshelvesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BookshelvesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Bookshelves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookshelf>>> GetBookshelves()
        {
            if (_context.Bookshelves == null)
            {
                return NotFound();
            }
            return await _context.Bookshelves.ToListAsync();
        }

        // GET: api/Bookshelves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bookshelf>> GetBookshelf(int id)
        {
            if (_context.Bookshelves == null)
            {
                return NotFound();
            }
            var bookshelf = await _context.Bookshelves.FindAsync(id);

            if (bookshelf == null)
            {
                return NotFound();
            }

            return bookshelf;
        }

        // PUT: api/Bookshelves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookshelf(int id, Bookshelf bookshelf)
        {
            if (id != bookshelf.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookshelf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookshelfExists(id))
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

        // POST: api/Bookshelves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bookshelf>> PostBookshelf(Bookshelf bookshelf)
        {
            if (_context.Bookshelves == null)
            {
                return Problem("Entity set 'ApplicationContext.Bookshelves'  is null.");
            }
            _context.Bookshelves.Add(bookshelf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookshelf", new { id = bookshelf.Id }, bookshelf);
        }

        // DELETE: api/Bookshelves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookshelf(int id)
        {
            if (_context.Bookshelves == null)
            {
                return NotFound();
            }
            var bookshelf = await _context.Bookshelves.FindAsync(id);
            if (bookshelf == null)
            {
                return NotFound();
            }

            _context.Bookshelves.Remove(bookshelf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookshelfExists(int id)
        {
            return (_context.Bookshelves?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
