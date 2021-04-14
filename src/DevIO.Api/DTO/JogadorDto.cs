using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.DTO
{
    public class JogadorDto
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string IdClash { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Celular { get; set; }

        public string Nome { get; set; }

    }
}
