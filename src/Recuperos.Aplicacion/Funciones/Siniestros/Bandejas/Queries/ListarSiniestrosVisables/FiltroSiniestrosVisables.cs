using System;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosVisables
{
    public class FiltroSiniestrosVisables
    {
        public string NumeroSiniestro { get; set; }

        public string InnerNumeroSiniestro { get; set; }
        public int? Compania { get; set; }

        public DateTime? FechaDesde{ get; set; }
        public DateTime? FechaHasta { get; set; }

        public int? EstadoId { get; set; }
        public int? Probabilidad { get; set; }

        public int? EjecutivoId { get; set; }

        public int? Region { get; set; }
    }
}
