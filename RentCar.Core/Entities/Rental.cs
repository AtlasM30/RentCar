using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Core.Entities
{
    public class Rental
    {
        public int id { get; set; }
        public string nomeCliente { get; set; }
        public DateTime inicioAluguel { get; set; }
        public DateTime fimAluguel { get; set; }
        public int vehicleId { get; set; }
        public Vehicle vehicle { get; set; }
    }
}
