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
        public async Task<ActionResult<IEnumerable<TipoVenda>>> GetTipoVendas()
        {
            return await _context.TipoVendas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVenda>> GetTipoVenda(int id)
        {
            var tipoVenda = await _context.TipoVendas.FindAsync(id);

            if (tipoVenda == null)
            {
                return NotFound();
            }

            return tipoVenda;
        }

        [HttpPost]
        public async Task<ActionResult<TipoVenda>> PostTipoVenda(TipoVenda tipoVenda)
        {
            _context.TipoVendas.Add(tipoVenda);
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
            var tipoVenda = await _context.TipoVendas.FindAsync(id);
            if (tipoVenda == null)
            {
                return NotFound();
            }

            _context.TipoVendas.Remove(tipoVenda);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
