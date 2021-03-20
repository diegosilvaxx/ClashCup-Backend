﻿using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.DTO
{
    public class FornecedorDto
    {
        [Key]
        public Guid Id { get; set; }

        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string NomeAtendente { get; set; }
        public EnderecoFornecedorDto Endereco { get; set; }
        public string FornecedorAtivo { get; set; }
        public string TipoFornecedor { get; set; }
        public string Observacao { get; set; }

        /* EF Relations */
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
