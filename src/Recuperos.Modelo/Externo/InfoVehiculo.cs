using System;

namespace Recuperos.Modelo.Externo
{
    public class InfoVehiculo
    {
        public InfoVehiculo()
        {
            FechaConsulta = DateTime.Now;
        }

        public int Id { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string LaVersion { get; set; }
        public int? Anio { get; set; }
        public string Color { get; set; }
        public string NumeroMotor { get; set; }
        public string NumeroChasis { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Origen { get; set; }
        public InfoPersona InfoPersona { get; set; }
        public int? InfoPersonaId { get; set; }
    }
}
