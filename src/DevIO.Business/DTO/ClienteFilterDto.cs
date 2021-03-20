using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.DTO
{
    public class ClienteFilterDto
    {
        public string Key { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string TipoCliente { get; set; }
        public string Ativo { get; set; }
    }
}
