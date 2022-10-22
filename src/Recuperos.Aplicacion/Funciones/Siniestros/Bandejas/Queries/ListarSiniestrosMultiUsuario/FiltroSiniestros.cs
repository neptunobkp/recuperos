using System;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario
{
    public class FiltroSiniestros
    {
        public int? NumeroSiniestro { get; set; }

        public string InnerNumeroSiniestro { get; set; }
        public string OtraCompania { get; set; }

        public int? Compania { get; set; }

        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }

        public int? EstadoId { get; set; }
        public int? Probabilidad { get; set; }

        public int? EjecutivoId { get; set; }

        public string EjecutivoNombre { get; set; }

        public int? EjecutivoIdPermitible { get; set; }

        public int? Region { get; set; }

        public bool TieneAlgunFiltro
        {
            get
            {
                return 
                       !string.IsNullOrEmpty(EjecutivoNombre) || 
                       NumeroSiniestro.HasValue ||
                       FechaHasta.HasValue ||
                       Compania.HasValue ||
                       FechaDesde.HasValue ||
                       EstadoId.HasValue ||
                       Probabilidad.HasValue ||
                       EjecutivoId.HasValue ||
                       Region.HasValue;
            }
        }
    }
}
