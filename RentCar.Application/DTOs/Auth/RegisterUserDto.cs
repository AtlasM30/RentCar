using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentCar.Application.DTOs.Auth
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        public string nomeUsuario { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public string senha { get; set; }
    }
}
