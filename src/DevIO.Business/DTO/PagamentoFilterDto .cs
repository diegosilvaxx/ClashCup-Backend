using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.DTO
{
    public class PagamentoFilterDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string CPF { get; set; }
        public string FormaPagamento { get; set; }
    }
}
