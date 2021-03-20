using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.DTO
{
    public class FornecedorFilterDto
    {
        public Guid Id { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Ativo { get; set; }
    }
}
