using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.DTO
{
    public class UpdatePasswordDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Password { get; set; }
        public string Email { get; set; }

        public string ConfirmPassword { get; set; }
        public string Token { get; set; }

    }
}
