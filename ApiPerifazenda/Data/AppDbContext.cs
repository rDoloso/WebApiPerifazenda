using Microsoft.EntityFrameworkCore;
using WebApiPerifazenda.Model;

namespace ApiPerifazenda.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets para todas as entidades
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<TipoCliente> TipoCliente { get; set; }
        public DbSet<TipoFuncionario> TipoFuncionario { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<TipoVenda> TipoVenda { get; set; }
        public DbSet<TipoLogin> TipoLogin { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<ProdutoVenda> ProdutoVenda { get; set; }
        public DbSet<Login> Login { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamento 1:1 entre Login e Cliente
            modelBuilder.Entity<Login>()
                .HasOne(l => l.Cliente)
                .WithOne()  // Cada cliente tem um único login
                .HasForeignKey<Login>(l => l.FkCliente)  // A chave estrangeira fkCliente na tabela Login
                .OnDelete(DeleteBehavior.SetNull);  // Caso o cliente seja excluído, o login pode ser setado como NULL

            // Relacionamento 1:1 entre Login e Funcionario
            modelBuilder.Entity<Login>()
                .HasOne(l => l.Funcionario)
                .WithOne()  // Cada funcionário tem um único login
                .HasForeignKey<Login>(l => l.FkFuncionario)  // A chave estrangeira fkFuncionario na tabela Login
                .OnDelete(DeleteBehavior.SetNull);  // Caso o funcionário seja excluído, o login pode ser setado como NULL

            // Configuração do relacionamento Estoque ↔ Produto
            modelBuilder.Entity<Estoque>()
                .HasOne(e => e.Produto)
                .WithMany() 
                .HasForeignKey(e => e.fkProduto)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração do relacionamento Produtos ↔ Fornecedores
            modelBuilder.Entity<Produto>()
            .HasOne(p => p.Fornecedor)
            .WithMany(f => f.Produtos) // Um fornecedor pode ter vários produtos
            .HasForeignKey(p => p.FkFornecedor) // A chave estrangeira é fkFornecedor
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Venda>()
            .HasOne(v => v.Cliente)
            .WithMany()
            .HasForeignKey(v => v.FkCliente)  
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Funcionario)
                .WithMany()
                .HasForeignKey(v => v.FkFuncionario)  
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProdutoVenda>()
            .HasOne(pv => pv.Produto)          // Relacionamento com Produto
            .WithMany()                        //Pode ter muitos ProdutoVenda
            .HasForeignKey(pv => pv.FkProduto) // Chave estrangeira fkProduto
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Produto>()
            .Property(p => p.Preco)
            .HasPrecision(10, 2); // Definindo a precisão (18) e a escala (2)

            // Configuração de 'ValorTotal' para a entidade 'Venda'
            modelBuilder.Entity<Venda>()
                .Property(v => v.ValorTotal)
                .HasPrecision(10, 2); // Definindo a precisão (18) e a escala (2)
        }

        

    }
}
