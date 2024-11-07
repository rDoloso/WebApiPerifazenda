using ApiPerifazenda.Service;
using Microsoft.AspNetCore.Mvc;
using WebApiPerifazenda.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiPerifazenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteService;

        // Injeção de dependência para o serviço de clientes
        public ClienteController(IClienteInterface clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteService.GetClientesAsync();
            return Ok(clientes);
        }

        // GET: api/cliente/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // POST: api/cliente
        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Cliente não pode ser nulo.");
            }

            var novoCliente = await _clienteService.CreateClienteAsync(cliente);

            // Retorna o status 201 com o cliente recém-criado e o URI para acessar o novo recurso
            return CreatedAtAction(nameof(GetCliente), new { id = novoCliente.IdCliente }, novoCliente);
        }

        // PUT: api/cliente/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCliente(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest("O ID do cliente não corresponde.");
            }

            var resultado = await _clienteService.UpdateClienteAsync(id, cliente);

            if (!resultado)
            {
                return NotFound();
            }

            return NoContent();  // Status 204 - Não há conteúdo, mas a atualização foi bem-sucedida
        }

        // DELETE: api/cliente/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            var resultado = await _clienteService.DeleteClienteAsync(id);

            if (!resultado)
            {
                return NotFound();
            }

            return NoContent();  // Status 204 - Cliente excluído com sucesso
        }
    }
}
