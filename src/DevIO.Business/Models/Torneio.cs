using System;

namespace DevIO.Business.Models
{
    public class Torneio : Entity
    {
        public string ValorTorneio { get; set; }
        public string Senha { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioAbertura { get; set; }
        public string NomeTorneio { get; set; }
        public string Descricao { get; set; }
        public DateTime DataTorneio { get; set; }
        public bool Excluido { get; set; }
    }
}