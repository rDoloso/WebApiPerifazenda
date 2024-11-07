using System.ComponentModel.DataAnnotations;

namespace WebApiPerifazenda.Model
{
    public class ProdutoVenda
    {
        [Key] // Define a chave primária
        public int IdProdutoVenda { get; set; }
        public string CodVenda { get; set; }
        public int FkProduto { get; set; }
        public int Quantidade { get; set; }

        // Propriedade de navegação para a entidade Produto
        public Produto Produto { get; set; }
    }
}
