using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Core.Entities
{
    public class User
    {
        public int id { get; set; }

        public string nomeUsuario { get; set; }

        public string senhaHash { get; set; }
    }
}
