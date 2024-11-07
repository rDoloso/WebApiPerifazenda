﻿using System.ComponentModel.DataAnnotations;

namespace WebApiPerifazenda.Model
{
    public class Cliente
    {
        [Key] // Define a chave primária
        public int IdCliente { get; set; }
        public int TipoCliente { get; set; }
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string CidadeEstado { get; set; }
        public string? Complemento { get; set; }
    }
}
