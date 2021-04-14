using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.DTO
{
    public class PagamentoDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string FormaPagamento { get; set; }
        public string IdClash { get; set; }
        public Guid JogadorId { get; set; }
        public Guid TorneioId { get; set; }
    }
}
