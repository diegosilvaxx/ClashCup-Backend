using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.DTO
{
    public class ClienteDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public DateTime DataNascimento { get; set; }
        public EnderecoClienteDto Endereco { get; set; }
        public string ClienteAtivo { get; set; }
        public string Observacao { get; set; }
        public string TipoCliente { get; set; }
    }
}
