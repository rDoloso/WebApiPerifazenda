namespace WebApiPerifazenda.Model
{
    public class ProdutoVenda
    {
        public int IdProdutoVenda { get; set; }
        public string CodVenda { get; set; }
        public int FkProduto { get; set; }
        public int Quantidade { get; set; }

        public Produto Produto { get; set; }
    }
}
