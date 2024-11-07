using System.ComponentModel.DataAnnotations;

namespace WebApiPerifazenda.Model
{
    public class Fornecedor
    {
        [Key] // Define a chave primária
        public int IdFornecedor { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string CidadeEstado { get; set; }
        public string? Complemento { get; set; }


        // Lista de produtos fornecidos por este fornecedor
        public ICollection<Produto> Produtos { get; set; }
    }
}
