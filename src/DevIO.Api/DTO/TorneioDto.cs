using DevIO.Business.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.DTO
{
    public class TorneioDto
    {
        [Key]
        public Guid Id { get; set; }

        public string ValorTorneio { get; set; }
        public string Senha { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioAbertura { get; set; }
        public string NomeTorneio { get; set; }

        public string DataTorneio { get; set; }
        public string Descricao { get; set; }
        public bool Excluido { get; set; }
    }
}
