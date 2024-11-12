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

        public async Task<bool> VerificarClientePorCpf(string cpf)
        {
            //return await _context.Cliente.AnyAsync(c => c.Cpf == cpf);
            var cliente = await _context.Cliente
                                         .FirstOrDefaultAsync(c => c.Cpf == cpf);
            return cliente != null; // Retorna true se o CNPJ já existir

        }

        // Verificar se o cliente já existe pelo CNPJ
        public async Task<bool> VerificarClientePorCnpj(string cnpj)
        {
            var cliente = await _context.Cliente
                                         .FirstOrDefaultAsync(c => c.Cnpj == cnpj);
            return cliente != null; // Retorna true se o CNPJ já existir

            //return await _context.Cliente.AnyAsync(c => c.Cnpj == cnpj);
        }
    }
}
