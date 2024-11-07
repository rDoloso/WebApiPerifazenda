using System.ComponentModel.DataAnnotations;

namespace WebApiPerifazenda.Model
{
    public class TipoLogin
    {
        [Key] // Define a chave primária
        public int IdTipoLogin { get; set; }
        public string Descricao { get; set; }
    }
}
