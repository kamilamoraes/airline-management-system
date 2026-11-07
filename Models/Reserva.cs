namespace AirlineManagementSystem.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string NomePassageiro { get; set; } = string.Empty;
        public string NumeroVoo { get; set; } = string.Empty;
        public string Assento { get; set; } = string.Empty;
        public string CodigoReserva { get; set; } = string.Empty;
    }
}