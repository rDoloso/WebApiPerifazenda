using ApiPerifazenda.Model;
using ApiPerifazenda.Service;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiPerifazenda.Model;
using static ApiPerifazenda.Service.ServiceGeral;

namespace ApiPerifazenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginInterface _loginService;

        public LoginController(ILoginInterface loginService)
        {
            _loginService = loginService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllLogin()
        {
            var logins = await _loginService.GetAllLogins();
            return Ok(logins);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoginById(int id)
        {
            var login = await _loginService.GetLoginById(id);
            if (login == null)
            {
                return NotFound();
            }
            return Ok(login);
        }


        [HttpPost]
        public async Task<IActionResult> CreateLogin([FromBody] Login login)
        {
            if (login == null)
            {
                return BadRequest("Login data is required.");
            }

            var createdLogin = await _loginService.CreateLogin(login);
            return CreatedAtAction(nameof(GetLoginById), new { id = createdLogin.IdLogin }, createdLogin);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLogin(int id, [FromBody] Login login)
        {
            if (login == null || id != login.IdLogin)
            {
                return BadRequest();
            }

            var result = await _loginService.UpdateLogin(id, login);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin(int id)
        {
            var result = await _loginService.DeleteLogin(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpPost("verificar")]
        public async Task<IActionResult> VerificarLogin([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Senha))
            {
                return BadRequest("Username and password are required.");
            }

            var login = await _loginService.VerificarLogin(loginRequest.Username, loginRequest.Senha);

            if (login != null)
            {
                return Ok(new
                {
                    Message = "Login bem-sucedido.",
                    FkCliente = login.FkCliente,
                    FkFuncionario = login.FkFuncionario
                });
            }
            else
            {
                return Unauthorized(new { Message = "Usuário ou senha inválidos." });
            }
        }

       

        [HttpPost("criar")]
        public async Task<IActionResult> CriarLogin([FromBody] CriarLoginRequest request)
        {
            var resultado = await _loginService.CriarLogin(request.Username, request.Email, request.Senha, request.IdFuncionario, request.IdCliente);

            if (resultado == ResultadoCriarLogin.Sucesso)
            {
                return Ok(new { message = "Login criado com sucesso!" });
            }
            else if (resultado == ResultadoCriarLogin.UsuarioOuEmailJaExistente)
            {
                return BadRequest(new { message = "Usuário ou email já existente." });
            }
            else
            {
                return StatusCode(500, new { message = "Erro ao criar login." });
            }
        }

        [HttpGet("verificar-usuario")]
        public async Task<IActionResult> VerificarUsername([FromQuery] string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Username é necessário.");
            }

            var loginExistente = await _loginService.VerificarUsernameExistente(username);
            if (loginExistente != false)
            {
                return Conflict(new { message = "Username já existe." });  // 409 Conflict
            }

            return Ok(); // Username não existe
        }


        //REQUESTS
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Senha { get; set; }
        }

        public class CriarLoginRequest
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }
            public int TipoLogin { get; set; } = 1;
            public int IdFuncionario { get; set; } = 0;
            public int IdCliente { get; set; } = 0;
        }
    }
}
