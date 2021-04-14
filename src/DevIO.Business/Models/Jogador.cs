using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace DevIO.Business.Models
{
    public class Jogador : Entity
    {
        [Key]
        public Guid PagamentoId { get; set; }
        public string UserId { get; set; }

        public string Email { get; set; }

        public string IdClash { get; set; }

        public string Celular { get; set; }

        public string Nome { get; set; }

        public List<Pagamento> Pagamento { get; set; }
    }
}