namespace Recuperos.Aplicacion.Interfaces.Servicios.RnvmLocal.Models
{
    public class Vehiculo
    {
        public int? Anio { get; set; }
        public string Color { get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }
        public string NumeroChasis { get; set; }
        public string NumeroMotor { get; set; }
        public string Patente { get; set; }
    }
}