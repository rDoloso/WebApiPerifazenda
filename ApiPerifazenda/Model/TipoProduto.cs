using System.ComponentModel.DataAnnotations;

namespace WebApiPerifazenda.Model
{
    public class TipoProduto
    {
        [Key] // Define a chave primária
        public int IdTipoProduto { get; set; }
        public string Descricao { get; set; }
    }
}
