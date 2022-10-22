using System.ComponentModel.DataAnnotations.Schema;

namespace Recuperos.Modelo.Entidades
{
    public class TerceroVehiculo
    {
        [ForeignKey("Tercero")]
        public int TerceroVehiculoId { get; set; }

        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string LaVersion { get; set; }
        public int? Anio { get; set; }
        public string Color { get; set; }
        public string NumeroMotor { get; set; }
        public string NumeroChasis { get; set; }

        public virtual Tercero Tercero { get; set; }

    }
}
