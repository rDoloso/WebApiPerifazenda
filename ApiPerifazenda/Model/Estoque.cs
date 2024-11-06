namespace WebApiPerifazenda.Model
{
    public class Estoque
    {
        public int IdEstoque { get; set; }
        public int FkProduto { get; set; }
        public int QtdEstoque { get; set; }
        public DateTime DataModificacao { get; set; }

        public Produto Produto { get; set; }
    }
}
