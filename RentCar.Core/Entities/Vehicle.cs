namespace RentCar.Core.Entities
{
    public class Vehicle
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int ano { get; set; }
        public string placa { get; set; }
        public decimal valorDiaria { get; set; }
        public bool disponivel { get; set; } = true;
    }
}
