using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Recuperos.Modelo.Entidades
{
    public class Siniestro
    {
        public Siniestro()
        {
            Archivos = new List<ArchivoAdjunto>();
            SolicitudesVisto = new List<SolicitudVisto>();
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public int Riesgo { get; set; }

        public DateTime? FechaDenuncio { get; set; }
        public DateTime? FechaSiniestro { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? Prescripcion { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
        public DateTime FechaImportacion { get; set; }
        public DateTime? FechaUltimoCambioEstado { get; set; }
        public DateTime? FechaUltimoCambioEtapa { get; set; }
        public DateTime? FechaRecupero { get; set; }
        public string Ramo { get; set; }


        public int Compania { get; set; }
        public int Probabilidad { get; set; }

        public decimal? Provision { get; set; }
        public decimal? GastoUf { get; set; }
        public int? MontoOr { get; set; }

        public int? EjecutivoId { get; set; }
        public Usuario Ejecutivo { get; set; }

        public int? EstadoId { get; set; }
        public Estado Estado { get; set; }


        public ICollection<SolicitudVisto> SolicitudesVisto { get; set; }

        public List<ArchivoAdjunto> Archivos { get; set; }


        public string CodigoSucursal { get; set; }
        public string TipoDocumento { get; set; }
        public long NumeroPoliza { get; set; }
        public int NumeroItem { get; set; }

        public string TipoDanio { get; set; }
        public string TipoOrden { get; set; }
        public bool? Aceptado { get; set; }

        public string ActualizadoPor { get; set; }
        public string UltimoEjecutivoAsignado { get; set; }
        public bool Destacado { get; set; }
        public int? EstadoVisado { get; set; }

        public string CompaniaTercero { get; set; }

        public int? Region { get; set; }
        public int? NumeroTercero { get; set; }

        public DateTime? FechaPromesa { get; set; }
        public int? Monto { get; set; }
        public string Telefono { get; set; }
        public DateTime? FechaCarta { get; set; }
        public int? MontoSolicitado { get; set; }
        public string EstudioAbogados { get; set; }
        public string Daterc { get; set; }
    }


}