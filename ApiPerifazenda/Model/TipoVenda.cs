using System.ComponentModel.DataAnnotations;

namespace WebApiPerifazenda.Model
{
    public class TipoVenda
    {
        [Key] // Define a chave primária
        public int IdTipoVenda { get; set; }
        public string Descricao { get; set; }
    }
}
