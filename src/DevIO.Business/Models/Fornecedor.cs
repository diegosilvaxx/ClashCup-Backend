using System;
using System.Collections.Generic;

namespace DevIO.Business.Models
{
    public class Fornecedor : Entity
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string NomeAtendente { get; set; }
        public EnderecoFornecedor Endereco { get; set; }
        public string FornecedorAtivo { get; set; }
        public string TipoFornecedor { get; set; }
        public string Observacao { get; set; }

        /* EF Relations */
        public IEnumerable<Produto> Produtos { get; set; }
    }
}