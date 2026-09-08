using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Application.DTOs.Vehicle
{
    public class UpdateVehicleDTO
    {
        public string marca { get; set; }
        public string modelo { get; set; }
        public int ano { get; set; }
        public string placa { get; set; }
        public decimal valorDiaria { get; set; }
        public bool disponivel { get; set; } = true;
    }
}
