using System.Text;

namespace ApiPerifazenda.Service
{
    public class ServiceGeral
    {

        public string GerarCodigoVenda()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new StringBuilder(8);

            for (int i = 0; i < 8; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
        public enum ResultadoCriarLogin
        {
            Sucesso,
            UsuarioOuEmailJaExistente,
            Erro
        }
    }
}
