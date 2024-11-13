using ApiPerifazenda.Model;
using WebApiPerifazenda.Model;
using static ApiPerifazenda.Controllers.LoginController;
using static ApiPerifazenda.Service.ServiceGeral;

namespace ApiPerifazenda.Service
{
    public interface ILoginInterface
    {
        Task<bool> VerificarUsernameExistente(string username);
        Task<IEnumerable<Login>> GetAllLogins();
        Task<Login> GetLoginById(int id);
        Task<Login> CreateLogin(Login login);
        Task<bool> UpdateLogin(int id, Login login);
        Task<bool> DeleteLogin(int id);

        Task<Login> VerificarLogin(string username, string senha);

        Task<ResultadoCriarLogin> CriarLogin(string usuario, string email, string senha, int idFuncionario = 0, int idCliente = 0);

    }
}
