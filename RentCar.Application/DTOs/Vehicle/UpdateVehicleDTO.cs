using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentCar.Application.DTOs.Vehicle
{
    public class UpdateVehicleDTO
    {
        [Required(ErrorMessage = "A marca é obrigatória.")]
        public string marca { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório.")]
        public string modelo { get; set; }

        [Range(1900, 2100, ErrorMessage = "O ano deve estar entre 1900 e 2100.")]
        public int ano { get; set; }
        [Required(ErrorMessage = "A placa é obrigatória.")]
        public string placa { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor da diária deve ser maior que zero.")]
        public decimal valorDiaria { get; set; }
        public bool disponivel { get; set; } = true;
    }
}
