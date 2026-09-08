using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentCar.Application.DTOs.Rental
{
    public class CreateRentalDto
    {
        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        public string nomeCliente { get; set; }
        [Required(ErrorMessage = "A data de início do aluguel é obrigatória.")]
        public DateTime inicioAluguel { get; set; }
        [Required(ErrorMessage = "A data de fim do aluguel é obrigatória.")]
        public DateTime fimAluguel { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "O veículo informado é inválido.")]
        public int vehicleId { get; set; }
    }
}
