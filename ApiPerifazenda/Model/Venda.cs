using System.ComponentModel.DataAnnotations;

namespace WebApiPerifazenda.Model
{
    public class Venda
    {
        [Key] // Define a chave primária
        public int IdVenda { get; set; }
        public int TipoVenda { get; set; }
        public string CodVenda { get; set; }
        public DateTime? DataVenda { get; set; }
        public int? FkCliente { get; set; }
        public int? FkFuncionario { get; set; }
        public decimal ValorTotal { get; set; }

        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
