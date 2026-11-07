namespace AirlineManagementSystem.Models
{
    public class Aeronave
    {
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public string Fabricante { get; set; } = string.Empty;
        public int Capacidade { get; set; }
        public string CodigoIdentificacao { get; set; } = string.Empty;
    }
}