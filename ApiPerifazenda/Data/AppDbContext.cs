using Microsoft.EntityFrameworkCore;
using WebApiPerifazenda.Model;

namespace ApiPerifazenda.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets para todas as entidades
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<TipoCliente> TipoClientes { get; set; }
        public DbSet<TipoFuncionario> TipoFuncionarios { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }
        public DbSet<TipoVenda> TipoVendas { get; set; }
        public DbSet<TipoLogin> TipoLogins { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ProdutoVenda> ProdutosVenda { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}
