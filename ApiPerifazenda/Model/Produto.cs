namespace WebApiPerifazenda.Model
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public int TipoProduto { get; set; }
        public string CodProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int FkFornecedor { get; set; }

        public Fornecedor Fornecedor { get; set; } // Relacionamento com Fornecedor
    }
}
