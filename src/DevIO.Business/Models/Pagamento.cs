using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Business.Models
{
    public class Pagamento : Entity
    {
        [Key]
        public Guid JogadorId { get; set; }
        public Guid TorneioId { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string FormaPagamento { get; set; }
        public string IdClash { get; set; }
        /* EF Relations */
        public Jogador Jogador { get; set; }
        public Torneio Torneio { get; set; }
    }
}