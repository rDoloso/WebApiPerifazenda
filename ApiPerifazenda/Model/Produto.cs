using System.ComponentModel.DataAnnotations;

namespace WebApiPerifazenda.Model
{
    public class Produto
    {
        [Key] // Define a chave primária
        public int IdProduto { get; set; }
        public int TipoProduto { get; set; }
        public string CodProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int? FkFornecedor { get; set; }

        public Fornecedor Fornecedor { get; set; } // Relacionamento com Fornecedor
    }
}
