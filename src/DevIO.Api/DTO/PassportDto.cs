using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.DTO
{
    public class PassportDto
    {
        public string Nome { get; set; }
        public string Data { get; set; }
        public string Senha { get; set; }
        public string HorarioAbertura { get; set; }
        public string HorarioInicio { get; set; }
        public string ValorTorneio { get; set; }
        public string Tag { get; set; }
    }
}
