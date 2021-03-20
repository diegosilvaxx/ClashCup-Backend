using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace DevIO.Business.Models
{
    public class Cliente : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public DateTime DataNascimento { get; set; }
        public string ClienteAtivo { get; set; }

        public string Observacao { get; set; }
        public string TipoCliente { get; set; }
        public EnderecoCliente Endereco { get; set; }
    }
}