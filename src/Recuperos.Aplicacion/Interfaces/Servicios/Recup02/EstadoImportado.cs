using System;

namespace Recuperos.Aplicacion.Interfaces.Servicios.Recup02
{
    public class EstadoImportado
    {
        public decimal? EjecutivoId { get; set; }
        public decimal? Estadoid { get; set; }
        public DateTime? FechaAsignacion { get; set; }

        public decimal? Probabilidad { get; set; }

        public DateTime? Fecharecupero { get; set; }

        public string Daterc { get; set; }
        public string CompaniaTercero { get; set; }
        public string Numerotercero { get; set; }
        public string FechaCarta { get; set; }
        public string FechaPromesa { get; set; }
        public string MontoSolicitado { get; set; }
        public string Monto { get; set; }
        public string Telefono { get; set; }
    }
}