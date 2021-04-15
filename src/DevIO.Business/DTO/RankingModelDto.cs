using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.DTO
{
    public class RankingModelDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Player { get; set; }
        public string Cla { get; set; }
        public string Arena { get; set; }
        public string IdClash { get; set; }
        public int Vitoria { get; set; }
        public string Trofeu { get; set; }
    }
}
