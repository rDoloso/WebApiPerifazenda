using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPerifazenda.Migrations
{
    /// <inheritdoc />
    public partial class AjustePrecisionDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Produtos_ProdutoIdProduto",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Clientes_ClienteIdCliente",
                table: "Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Funcionarios_FuncionarioIdFuncionario",
                table: "Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorIdFornecedor",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosVenda_Produtos_ProdutoIdProduto",
                table: "ProdutosVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteIdCliente",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Funcionarios_FuncionarioIdFuncionario",
                table: "Vendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendas",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_ClienteIdCliente",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_FuncionarioIdFuncionario",
                table: "Vendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoVendas",
                table: "TipoVendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoProdutos",
                table: "TipoProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoLogins",
                table: "TipoLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoFuncionarios",
                table: "TipoFuncionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoClientes",
                table: "TipoClientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutosVenda",
                table: "ProdutosVenda");

            migrationBuilder.DropIndex(
                name: "IX_ProdutosVenda_ProdutoIdProduto",
                table: "ProdutosVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_FornecedorIdFornecedor",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logins",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_ClienteIdCliente",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_FuncionarioIdFuncionario",
                table: "Logins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estoques",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_ProdutoIdProduto",
                table: "Estoques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "FuncionarioIdFuncionario",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ProdutoIdProduto",
                table: "ProdutosVenda");

            migrationBuilder.DropColumn(
                name: "FornecedorIdFornecedor",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "FuncionarioIdFuncionario",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "ProdutoIdProduto",
                table: "Estoques");

            migrationBuilder.RenameTable(
                name: "Vendas",
                newName: "Venda");

            migrationBuilder.RenameTable(
                name: "TipoVendas",
                newName: "TipoVenda");

            migrationBuilder.RenameTable(
                name: "TipoProdutos",
                newName: "TipoProduto");

            migrationBuilder.RenameTable(
                name: "TipoLogins",
                newName: "TipoLogin");

            migrationBuilder.RenameTable(
                name: "TipoFuncionarios",
                newName: "TipoFuncionario");

            migrationBuilder.RenameTable(
                name: "TipoClientes",
                newName: "TipoCliente");

            migrationBuilder.RenameTable(
                name: "ProdutosVenda",
                newName: "ProdutoVenda");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produto");

            migrationBuilder.RenameTable(
                name: "Logins",
                newName: "Login");

            migrationBuilder.RenameTable(
                name: "Funcionarios",
                newName: "Funcionario");

            migrationBuilder.RenameTable(
                name: "Fornecedores",
                newName: "Fornecedor");

            migrationBuilder.RenameTable(
                name: "Estoques",
                newName: "Estoque");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.RenameColumn(
                name: "FkProduto",
                table: "Estoque",
                newName: "fkProduto");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotal",
                table: "Venda",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "FkFuncionario",
                table: "Venda",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FkCliente",
                table: "Venda",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataVenda",
                table: "Venda",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "FkFornecedor",
                table: "Produto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Fornecedor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venda",
                table: "Venda",
                column: "IdVenda");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoVenda",
                table: "TipoVenda",
                column: "IdTipoVenda");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoProduto",
                table: "TipoProduto",
                column: "IdTipoProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoLogin",
                table: "TipoLogin",
                column: "IdTipoLogin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoFuncionario",
                table: "TipoFuncionario",
                column: "IdTipoFuncionario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoCliente",
                table: "TipoCliente",
                column: "IdTipoCliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoVenda",
                table: "ProdutoVenda",
                column: "IdProdutoVenda");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "IdProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Login",
                table: "Login",
                column: "IdLogin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionario",
                table: "Funcionario",
                column: "IdFuncionario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor",
                column: "IdFornecedor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estoque",
                table: "Estoque",
                column: "IdEstoque");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_FkCliente",
                table: "Venda",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_FkFuncionario",
                table: "Venda",
                column: "FkFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoVenda_FkProduto",
                table: "ProdutoVenda",
                column: "FkProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FkFornecedor",
                table: "Produto",
                column: "FkFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Login_FkCliente",
                table: "Login",
                column: "FkCliente",
                unique: true,
                filter: "[FkCliente] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Login_FkFuncionario",
                table: "Login",
                column: "FkFuncionario",
                unique: true,
                filter: "[FkFuncionario] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_fkProduto",
                table: "Estoque",
                column: "fkProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Produto_fkProduto",
                table: "Estoque",
                column: "fkProduto",
                principalTable: "Produto",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Login_Cliente_FkCliente",
                table: "Login",
                column: "FkCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Login_Funcionario_FkFuncionario",
                table: "Login",
                column: "FkFuncionario",
                principalTable: "Funcionario",
                principalColumn: "IdFuncionario",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Fornecedor_FkFornecedor",
                table: "Produto",
                column: "FkFornecedor",
                principalTable: "Fornecedor",
                principalColumn: "IdFornecedor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoVenda_Produto_FkProduto",
                table: "ProdutoVenda",
                column: "FkProduto",
                principalTable: "Produto",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Cliente_FkCliente",
                table: "Venda",
                column: "FkCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Funcionario_FkFuncionario",
                table: "Venda",
                column: "FkFuncionario",
                principalTable: "Funcionario",
                principalColumn: "IdFuncionario",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Produto_fkProduto",
                table: "Estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_Login_Cliente_FkCliente",
                table: "Login");

            migrationBuilder.DropForeignKey(
                name: "FK_Login_Funcionario_FkFuncionario",
                table: "Login");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Fornecedor_FkFornecedor",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoVenda_Produto_FkProduto",
                table: "ProdutoVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Cliente_FkCliente",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Funcionario_FkFuncionario",
                table: "Venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venda",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_FkCliente",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_FkFuncionario",
                table: "Venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoVenda",
                table: "TipoVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoProduto",
                table: "TipoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoLogin",
                table: "TipoLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoFuncionario",
                table: "TipoFuncionario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoCliente",
                table: "TipoCliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoVenda",
                table: "ProdutoVenda");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoVenda_FkProduto",
                table: "ProdutoVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_FkFornecedor",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Login",
                table: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Login_FkCliente",
                table: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Login_FkFuncionario",
                table: "Login");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionario",
                table: "Funcionario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estoque",
                table: "Estoque");

            migrationBuilder.DropIndex(
                name: "IX_Estoque_fkProduto",
                table: "Estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Venda",
                newName: "Vendas");

            migrationBuilder.RenameTable(
                name: "TipoVenda",
                newName: "TipoVendas");

            migrationBuilder.RenameTable(
                name: "TipoProduto",
                newName: "TipoProdutos");

            migrationBuilder.RenameTable(
                name: "TipoLogin",
                newName: "TipoLogins");

            migrationBuilder.RenameTable(
                name: "TipoFuncionario",
                newName: "TipoFuncionarios");

            migrationBuilder.RenameTable(
                name: "TipoCliente",
                newName: "TipoClientes");

            migrationBuilder.RenameTable(
                name: "ProdutoVenda",
                newName: "ProdutosVenda");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produtos");

            migrationBuilder.RenameTable(
                name: "Login",
                newName: "Logins");

            migrationBuilder.RenameTable(
                name: "Funcionario",
                newName: "Funcionarios");

            migrationBuilder.RenameTable(
                name: "Fornecedor",
                newName: "Fornecedores");

            migrationBuilder.RenameTable(
                name: "Estoque",
                newName: "Estoques");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "fkProduto",
                table: "Estoques",
                newName: "FkProduto");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotal",
                table: "Vendas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "FkFuncionario",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FkCliente",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataVenda",
                table: "Vendas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioIdFuncionario",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoIdProduto",
                table: "ProdutosVenda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produtos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "FkFornecedor",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FornecedorIdFornecedor",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Logins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioIdFuncionario",
                table: "Logins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Fornecedores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoIdProduto",
                table: "Estoques",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendas",
                table: "Vendas",
                column: "IdVenda");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoVendas",
                table: "TipoVendas",
                column: "IdTipoVenda");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoProdutos",
                table: "TipoProdutos",
                column: "IdTipoProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoLogins",
                table: "TipoLogins",
                column: "IdTipoLogin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoFuncionarios",
                table: "TipoFuncionarios",
                column: "IdTipoFuncionario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoClientes",
                table: "TipoClientes",
                column: "IdTipoCliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutosVenda",
                table: "ProdutosVenda",
                column: "IdProdutoVenda");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "IdProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logins",
                table: "Logins",
                column: "IdLogin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "IdFuncionario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores",
                column: "IdFornecedor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estoques",
                table: "Estoques",
                column: "IdEstoque");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteIdCliente",
                table: "Vendas",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FuncionarioIdFuncionario",
                table: "Vendas",
                column: "FuncionarioIdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosVenda_ProdutoIdProduto",
                table: "ProdutosVenda",
                column: "ProdutoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorIdFornecedor",
                table: "Produtos",
                column: "FornecedorIdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_ClienteIdCliente",
                table: "Logins",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_FuncionarioIdFuncionario",
                table: "Logins",
                column: "FuncionarioIdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_ProdutoIdProduto",
                table: "Estoques",
                column: "ProdutoIdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Produtos_ProdutoIdProduto",
                table: "Estoques",
                column: "ProdutoIdProduto",
                principalTable: "Produtos",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Clientes_ClienteIdCliente",
                table: "Logins",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Funcionarios_FuncionarioIdFuncionario",
                table: "Logins",
                column: "FuncionarioIdFuncionario",
                principalTable: "Funcionarios",
                principalColumn: "IdFuncionario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorIdFornecedor",
                table: "Produtos",
                column: "FornecedorIdFornecedor",
                principalTable: "Fornecedores",
                principalColumn: "IdFornecedor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosVenda_Produtos_ProdutoIdProduto",
                table: "ProdutosVenda",
                column: "ProdutoIdProduto",
                principalTable: "Produtos",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteIdCliente",
                table: "Vendas",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Funcionarios_FuncionarioIdFuncionario",
                table: "Vendas",
                column: "FuncionarioIdFuncionario",
                principalTable: "Funcionarios",
                principalColumn: "IdFuncionario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
