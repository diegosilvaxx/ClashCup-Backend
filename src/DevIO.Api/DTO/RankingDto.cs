using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.DTO
{
    public class RankingDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int IdClash { get; set; }
        public int Vitoria { get; set; }
        public Guid JogadorId { get; set; }
    }
}
