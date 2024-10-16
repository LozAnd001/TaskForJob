using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Shop.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstablishmentController: ControllerBase
    {
        private readonly DatabaseContext _context;
        public EstablishmentController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Establishment>>> GetEstablishments()
        {
            return await _context.Establishments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Establishment>> GetEstablishment(int id)
        {
            var establishment = await _context.Establishments.FindAsync(id);

            if (establishment == null)
            {
                return NotFound();
            }

            return establishment;
        }

        [HttpPost]
        public async Task<ActionResult<Establishment>> CreateEstablishment(Establishment establishment)
        {
            _context.Establishments.Add(establishment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstablishment), new { id = establishment.Id }, establishment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstablishment(int id, Establishment establishment)
        {
            if (id != establishment.Id)
            {
                return BadRequest();
            }

            _context.Entry(establishment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstablishment(int id)
        {
            var establishment = await _context.Establishments.FindAsync(id);
            if (establishment == null)
            {
                return NotFound();
            }

            _context.Establishments.Remove(establishment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
