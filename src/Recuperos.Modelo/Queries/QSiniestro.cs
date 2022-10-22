using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuperos.Modelo.Queries
{
    public class QSiniestro
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Compania { get; set; }
        public int Riesgo { get; set; }
        public DateTime? FechaDenuncio { get; set; }
        public DateTime? FechaSiniestro { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public int? EjecutivoId { get; set; }
        public string EjecutivoNombres { get; set; }
        public DateTime? FechaUltimoCambioEstado { get; set; }

        public int? EstadoId { get; set; }
        public int EtapaId { get; set; }
        public int? EstadoDiasAlerta { get; set; }
        public string EstadoNombre { get; set; }
        public string CompaniaTercero { get; set; }
        public int? Region { get; set; }
        public int? DiasGestion { get; set; }
        public int? AlertaGestion { get; set; }

        public int Probabilidad { get; set; }
        public int? Prescripcion { get; set; }
        public string Daterc { get; set; }


        public string ActualizadoPor { get; set; }
        public string EstadoDestinoNombre { get; set; }
        public int? EstadoVisado { get; set; }

        public decimal? GastoUf { get; set; }
        public decimal? MontoOr { get; set; }
        public decimal? Provision { get; set; }

        public string Aceptado { get; set; }

        public string TipoOrden { get; set; }
        public string TipoDanio { get; set; }
    }
}
