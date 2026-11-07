namespace AirlineManagementSystem.Models
{
    public class Voo
    {
        public int Id { get; set; } 
        public string NumeroVoo { get; set; } = string.Empty;
        public string Origem { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public string Horario { get; set; } = string.Empty;

    }
}