using System.ComponentModel.DataAnnotations;

namespace WebApiPerifazenda.Model
{
    public class TipoFuncionario
    {
        [Key] // Define a chave primária
        public int IdTipoFuncionario { get; set; }
        public string Descricao { get; set; }
    }
}
