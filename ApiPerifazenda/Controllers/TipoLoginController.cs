using ApiPerifazenda.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPerifazenda.Model;

namespace ApiPerifazenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoLoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoLoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoLogin>>> GetTipoLogins()
        {
            return await _context.TipoLogins.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoLogin>> GetTipoLogin(int id)
        {
            var tipoLogin = await _context.TipoLogins.FindAsync(id);

            if (tipoLogin == null)
            {
                return NotFound();
            }

            return tipoLogin;
        }

        [HttpPost]
        public async Task<ActionResult<TipoLogin>> PostTipoLogin(TipoLogin tipoLogin)
        {
            _context.TipoLogins.Add(tipoLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoLogin", new { id = tipoLogin.IdTipoLogin }, tipoLogin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoLogin(int id, TipoLogin tipoLogin)
        {
            if (id != tipoLogin.IdTipoLogin)
            {
                return BadRequest();
            }

            _context.Entry(tipoLogin).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoLogin(int id)
        {
            var tipoLogin = await _context.TipoLogins.FindAsync(id);
            if (tipoLogin == null)
            {
                return NotFound();
            }

            _context.TipoLogins.Remove(tipoLogin);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
