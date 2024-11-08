using ApiPerifazenda.Data;
using WebApiPerifazenda.Model;
using static ApiPerifazenda.Service.ServiceGeral;
using Microsoft.EntityFrameworkCore;

namespace ApiPerifazenda.Service
{
    public class VendaService : IVendaInterface
    {
        private readonly AppDbContext _context;

        public VendaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CriarVendaAsync(Venda venda)
        {
            try
            {
                // Gerar o código da venda
                ServiceGeral serviceGeral = new ServiceGeral();
                string codigoVenda = serviceGeral.GerarCodigoVenda();

                // Atribuindo o código à venda
                venda.CodVenda = codigoVenda;
                venda.DataVenda = DateTime.Now;

                // Adicionar a venda ao banco
                _context.Venda.Add(venda);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar a venda: " + ex.Message);
            }
        }



        public async Task<int> VerificarEstoqueAsync(int idProduto)
        {
            try
            {
                // Buscar o produto pelo ID
                var produto = await _context.Produto
                    .FirstOrDefaultAsync(p => p.IdProduto == idProduto);

                if (produto != null)
                {
                    // Encontrar o estoque relacionado ao produto
                    var estoque = await _context.Estoque
                        .FirstOrDefaultAsync(e => e.fkProduto == produto.IdProduto);

                    if (estoque != null)
                    {
                        return estoque.QtdEstoque; // Retorna a quantidade disponível no estoque
                    }
                }

                return 0; // Retorna 0 se o produto ou o estoque não foram encontrados
            }
            catch (Exception ex)
            {
                // Se ocorrer um erro ao acessar o banco de dados, lançar exceção
                throw new Exception("Erro ao verificar o estoque: " + ex.Message);
            }
        }

        public async Task<bool> AtualizarEstoqueAsync(int fkProduto, int quantidade)
        {
            try
            {
                // Verificar a quantidade atual no estoque
                int estoqueAtual = await VerificarEstoqueAsync(fkProduto);

                if (estoqueAtual >= quantidade)
                {
                    // Encontrar o estoque relacionado ao produto
                    var estoque = await _context.Estoque
                        .FirstOrDefaultAsync(e => e.fkProduto == fkProduto);

                    if (estoque != null)
                    {
                        // Atualizando o estoque (diminuindo a quantidade)
                        estoque.QtdEstoque -= quantidade;

                        // Salvar as mudanças no banco de dados
                        _context.Estoque.Update(estoque);
                        await _context.SaveChangesAsync();

                        return true; // Sucesso na atualização
                    }
                }

                return false; // Se o estoque não for suficiente ou o estoque não for encontrado
            }
            catch (Exception ex)
            {
                // Se ocorrer algum erro, lançar exceção
                throw new Exception("Erro ao atualizar o estoque: " + ex.Message);
            }
        }



        public async Task<bool> IncluirItemVendaAsync(string codVenda, int fkProduto, int quantidade)
        {
            try
            {
                // Verificar se a venda existe
                var venda = await _context.Venda
                    .FirstOrDefaultAsync(v => v.CodVenda == codVenda);

                if (venda == null)
                {
                    throw new Exception("Venda não encontrada.");
                }

                // Criar o objeto ProdutoVenda
                var produtoVenda = new ProdutoVenda
                {
                    CodVenda = codVenda,  // Usar o mesmo código da venda
                    FkProduto = fkProduto,
                    Quantidade = quantidade
                };

                // Adicionar o item de venda ao banco de dados
                _context.ProdutoVenda.Add(produtoVenda);
                await _context.SaveChangesAsync();

                // Atualizar o estoque
                await AtualizarEstoqueAsync(fkProduto, quantidade);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao incluir item na venda: " + ex.Message);
            }
        }


        public async Task<ProdutoVenda> ObterProdutoVendaAsync(int idProdutoVenda)
        {
            return await _context.ProdutoVenda
                .Include(pv => pv.Produto)
                .FirstOrDefaultAsync(pv => pv.IdProdutoVenda == idProdutoVenda);
        }



    }
}
