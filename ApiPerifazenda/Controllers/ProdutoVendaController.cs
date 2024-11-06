﻿using ApiPerifazenda.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPerifazenda.Model;

namespace ApiPerifazenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoVendaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoVendaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoVenda>>> GetProdutosVenda()
        {
            return await _context.ProdutosVenda
                .Include(pv => pv.Produto) // Incluindo os detalhes do produto
                .Include(pv => pv.CodVenda) // Incluindo os detalhes da venda
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoVenda>> GetProdutoVenda(int id)
        {
            var produtoVenda = await _context.ProdutosVenda
                .Include(pv => pv.Produto)
                .Include(pv => pv.CodVenda)
                .FirstOrDefaultAsync(pv => pv.IdProdutoVenda == id);

            if (produtoVenda == null)
            {
                return NotFound();
            }

            return produtoVenda;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoVenda>> PostProdutoVenda(ProdutoVenda produtoVenda)
        {
            _context.ProdutosVenda.Add(produtoVenda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutoVenda", new { id = produtoVenda.IdProdutoVenda }, produtoVenda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutoVenda(int id, ProdutoVenda produtoVenda)
        {
            if (id != produtoVenda.IdProdutoVenda)
            {
                return BadRequest();
            }

            _context.Entry(produtoVenda).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutoVenda(int id)
        {
            var produtoVenda = await _context.ProdutosVenda.FindAsync(id);
            if (produtoVenda == null)
            {
                return NotFound();
            }

            _context.ProdutosVenda.Remove(produtoVenda);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
