using System.ComponentModel.DataAnnotations;

namespace WebApiPerifazenda.Model
{
    public class Estoque
    {
        [Key] // Define a chave primária
        public int IdEstoque { get; set; }
        public int fkProduto { get; set; }
        public int QtdEstoque { get; set; }
        public DateTime DataModificacao { get; set; }

        public Produto Produto { get; set; }
    }
}
