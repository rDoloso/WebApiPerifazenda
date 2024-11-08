using Microsoft.AspNetCore.Mvc;
using WebApiPerifazenda.Model;
using ApiPerifazenda.Service;
using System.Threading.Tasks;
using LanguageExt;

namespace ApiPerifazenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaInterface _vendaService;

        public VendaController(IVendaInterface vendaService)
        {
            _vendaService = vendaService;
        }

       
        [HttpPost("criar")]
        public async Task<IActionResult> CriarVenda([FromBody] Venda venda)
        {
            if (venda == null)
            {
                return BadRequest("Venda não pode ser vazia.");
            }

            try
            {
                // Criar a venda, gerando o código da venda
                bool resultado = await _vendaService.CriarVendaAsync(venda);

                if (resultado)
                {
                    return Ok(new { mensagem = "Venda criada com sucesso!", codVenda = venda.CodVenda });
                }
                else
                {
                    return BadRequest("Erro ao criar a venda.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro interno ao processar a venda: " + ex.Message });
            }
        }

        [HttpGet("estoque/{idProduto}")]
        public async Task<IActionResult> VerificarEstoque(int idProduto)
        {
            if (idProduto <= 0)
            {
                return BadRequest("ID do produto inválido.");
            }

            try
            {
                int estoqueDisponivel = await _vendaService.VerificarEstoqueAsync(idProduto);

                return Ok(new { QuantidadeEmEstoque = estoqueDisponivel });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao verificar o estoque: " + ex.Message });
            }
        }


        [HttpPost("item")]
        public async Task<IActionResult> AdicionarItemVenda([FromBody] ProdutoVenda produtoVenda)
        {
            if (produtoVenda == null || produtoVenda.Quantidade <= 0 || produtoVenda.FkProduto <= 0 || string.IsNullOrEmpty(produtoVenda.CodVenda))
            {
                return BadRequest("Dados inválidos para o item da venda.");
            }

            try
            {
                // Adicionar item à venda utilizando o mesmo CodVenda
                bool resultado = await _vendaService.IncluirItemVendaAsync(produtoVenda.CodVenda, produtoVenda.FkProduto, produtoVenda.Quantidade);

                if (resultado)
                {
                    return Ok(new { mensagem = "Item adicionado à venda com sucesso!" });
                }
                else
                {
                    return BadRequest("Erro ao adicionar o item à venda.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao adicionar item: " + ex.Message });
            }
        }

    }
}

