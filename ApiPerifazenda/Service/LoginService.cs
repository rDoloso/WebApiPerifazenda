using ApiPerifazenda.Data;
using ApiPerifazenda.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebApiPerifazenda.Model;
using static ApiPerifazenda.Service.ServiceGeral;

namespace ApiPerifazenda.Service
{
    public class LoginService : ILoginInterface
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public (string hashSenha, string salt) HashSenha(string senha)
        {
            //Criar saltKey
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            string salt = Convert.ToBase64String(saltBytes);

            // Combinar o salt com a senha
            var senhaSalt = Encoding.UTF8.GetBytes(senha + salt);

            // Hashear a senha com SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(senhaSalt);
                string hashSenha = Convert.ToBase64String(hashBytes);

                return (hashSenha, salt);
            }
        }

        public static bool VerificarSenha(string senha, string saltKey, string hashSenha)
        {
            var senhaSalt = Encoding.UTF8.GetBytes(senha + saltKey);

            // Hashear a senha com SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(senhaSalt);
                string hashSenhaVerificar = Convert.ToBase64String(hashBytes);

                return hashSenhaVerificar == hashSenha; // Comparar hashes
            }
        }

        public async Task<IEnumerable<Login>> GetAllLogins()
        {
            return await _context.Login.ToListAsync();
        }

        public async Task<Login> GetLoginById(int id)
        {
            return await _context.Login.FindAsync(id);
        }

        public async Task<Login> CreateLoginAsync(Login login)
        {
            _context.Login.Add(login);
            await _context.SaveChangesAsync();
            return login;
        }

        public async Task<bool> UpdateLogin(int id, Login login)
        {
            if (id != login.IdLogin)
            {
                return false;
            }

            _context.Entry(login).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLogin(int id)
        {
            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return false;
            }

            _context.Login.Remove(login);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> VerificarLogin(string username, string senha)
        {
            bool senhaValida = false;

            // 1. Buscar o login do banco de dados com base no nome de usuário.
            var login = await _context.Login.FirstOrDefaultAsync(l => l.Username == username);
            if (login == null)
            {
                return senhaValida;  // Usuário não encontrado
            }

            // 2. Obter o salt e o hash da senha armazenados no banco de dados.
            string saltKey = login.SaltKey;
            string hashSenha = login.SenhaHash;

            // 3. Verificar se a senha fornecida corresponde ao hash armazenado.
            senhaValida = VerificarSenha(senha, saltKey, hashSenha);

            return senhaValida;
        }

        public Task<Login> CreateLogin(Login login)
        {
            throw new NotImplementedException();
        }


        public async Task<ResultadoCriarLogin> CriarLogin(string usuario, string email, string senha, int idFuncionario = 0, int idCliente = 0)
        {
            try
            {
                // 1. Verificar se já existe um usuário ou email no banco de dados
                bool usuarioOuEmailExistente = await _context.Login
                    .AnyAsync(l => l.Username == usuario || l.Email == email);

                if (usuarioOuEmailExistente)
                {
                    return ResultadoCriarLogin.UsuarioOuEmailJaExistente;
                }

                // 2. Gerar o Salt e Hash da senha
                var saltHash = HashSenha(senha);
                string saltKey = saltHash.salt;
                string hashSenha = saltHash.hashSenha;

                // 3. Criar um novo login
                var login = new Login
                {
                    Username = usuario,
                    Email = email,
                    SenhaHash = hashSenha,
                    SaltKey = saltKey,
                    TipoLogin = idFuncionario > 0 ? 1 : idCliente > 0 ? 2 : 0,  // 1 = Funcionario, 2 = Cliente, 0 = Caso contrário
                    FkFuncionario = idFuncionario > 0 ? idFuncionario : (int?)null,
                    FkCliente = idCliente > 0 ? idCliente : (int?)null
                };

                // 4. Salvar o login no banco de dados
                _context.Login.Add(login);
                await _context.SaveChangesAsync();

                return ResultadoCriarLogin.Sucesso;
            }
            catch (Exception)
            {
                return ResultadoCriarLogin.Erro;
            }
        }



    }
}
