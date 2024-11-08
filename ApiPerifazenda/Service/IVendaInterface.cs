using WebApiPerifazenda.Model;

namespace ApiPerifazenda.Service
{
    public interface IVendaInterface
    {
        Task<bool> CriarVendaAsync(Venda venda);
        Task<bool> IncluirItemVendaAsync(string codVenda, int fkProduto, int quantidade);
        Task<bool> AtualizarEstoqueAsync(int fkProduto, int quantidade);
        Task<ProdutoVenda> ObterProdutoVendaAsync(int idProdutoVenda);
        Task<int> VerificarEstoqueAsync(int idProduto);
    }
}
