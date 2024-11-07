using System.ComponentModel.DataAnnotations;

namespace WebApiPerifazenda.Model
{
    public class TipoCliente
    {
        [Key] // Define a chave primária
        public int IdTipoCliente { get; set; }
        public string Descricao { get; set; }
    }
}
