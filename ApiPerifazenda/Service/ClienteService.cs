using ApiPerifazenda.Data;
using ApiPerifazenda.Model;
using Microsoft.EntityFrameworkCore;
using WebApiPerifazenda.Model;


namespace ApiPerifazenda.Service
{
    public class ClienteService : IClienteInterface
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Cliente.FindAsync(id);
        }

        public async Task<Cliente> CreateClienteAsync(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> UpdateClienteAsync(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return false;
            }

            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return false;
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
