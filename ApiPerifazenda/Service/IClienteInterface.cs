using ApiPerifazenda.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPerifazenda.Model;
using static ApiPerifazenda.Controllers.ClienteController;

namespace ApiPerifazenda.Service
{
    public interface IClienteInterface
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<bool> VerificarClientePorCpf(string cpf);
        Task<bool> VerificarClientePorCnpj(string cnpj);
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<Cliente> CreateClienteAsync(Cliente cliente);
        Task<bool> UpdateClienteAsync(int id, Cliente cliente);
        Task<bool> DeleteClienteAsync(int id);
    }
}
