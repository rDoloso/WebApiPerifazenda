namespace WebApiPerifazenda.Model
{
    public class Login
    {
        public int IdLogin { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string SenhaHash { get; set; }
        public string SaltKey { get; set; }
        public DateTime DataCriacao { get; set; }
        public int TipoLogin { get; set; }
        public int? FkCliente { get; set; }
        public int? FkFuncionario { get; set; }

        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
