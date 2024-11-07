using ApiPerifazenda.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPerifazenda.Model;

namespace ApiPerifazenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoVendaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoVendaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoVenda>>> GetTipoVenda()
        {
            return await _context.TipoVenda.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVenda>> GetTipoVenda(int id)
        {
            var tipoVenda = await _context.TipoVenda.FindAsync(id);

            if (tipoVenda == null)
            {
                return NotFound();
            }

            return tipoVenda;
        }

        [HttpPost]
        public async Task<ActionResult<TipoVenda>> PostTipoVenda(TipoVenda tipoVenda)
        {
            _context.TipoVenda.Add(tipoVenda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoVenda", new { id = tipoVenda.IdTipoVenda }, tipoVenda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoVenda(int id, TipoVenda tipoVenda)
        {
            if (id != tipoVenda.IdTipoVenda)
            {
                return BadRequest();
            }

            _context.Entry(tipoVenda).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoVenda(int id)
        {
            var tipoVenda = await _context.TipoVenda.FindAsync(id);
            if (tipoVenda == null)
            {
                return NotFound();
            }

            _context.TipoVenda.Remove(tipoVenda);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
