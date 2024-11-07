using ApiPerifazenda.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPerifazenda.Model;

namespace ApiPerifazenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVenda()
        {
            return await _context.Venda
                .Include(v => v.Cliente)  // Incluindo o cliente
                .Include(v => v.Funcionario) // Incluindo o funcionário que realizou a venda
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Funcionario)
                .FirstOrDefaultAsync(v => v.IdVenda == id);

            if (venda == null)
            {
                return NotFound();
            }

            return venda;
        }

        [HttpPost]
        public async Task<ActionResult<Venda>> PostVenda(Venda venda)
        {
            _context.Venda.Add(venda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenda", new { id = venda.IdVenda }, venda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenda(int id, Venda venda)
        {
            if (id != venda.IdVenda)
            {
                return BadRequest();
            }

            _context.Entry(venda).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            _context.Venda.Remove(venda);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
