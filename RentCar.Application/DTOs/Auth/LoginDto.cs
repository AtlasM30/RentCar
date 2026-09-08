using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentCar.Application.DTOs.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        public string nomeUsuario { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string senha { get; set; }
    }
}
