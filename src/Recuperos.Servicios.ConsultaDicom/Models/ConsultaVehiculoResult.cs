namespace Recuperos.Servicios.ConsultaDicom.Models
{
    public class ConsultaVehiculoResult
    {
        public int Id { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string TipoVehiculo { get; set; }
        public string Anio { get; set; }
        public string NumeroMotor { get; set; }
        public string NumeroChasis { get; set; }
        public string Color { get; set; }

        public Propietario Propietario { get; set; }
    }
}