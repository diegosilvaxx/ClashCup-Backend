using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Models
{
    public class Ranking : Entity
    {
        public string IdClash { get; set; }
        public string Nome { get; set; }
        public int Vitoria { get; set; }
    }
}
