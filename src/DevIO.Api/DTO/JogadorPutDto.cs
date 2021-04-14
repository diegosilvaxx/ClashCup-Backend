using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.DTO
{
    public class JogadorPutDto
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }

        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        public string IdClash { get; set; }

        public string Celular { get; set; }

        public string Nome { get; set; }
        public string NovaSenha { get; set; }
        public string SenhaAntiga { get; set; }

    }
}
