using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recuperos.Modelo.Entidades
{
    public class SolicitudVisto
    {
        public int Id { get; set; }

        public DateTime FechaSolicitud { get; set; }

        [ForeignKey("EstadoTOrigen")]
        public int EstadoTOrigenId { get; set; }

        public Estado EstadoTOrigen { get; set; }

        [ForeignKey("EstadoTDestino")]
        public int EstadoTDestinoId { get; set; }
        public Estado EstadoTDestino { get; set; }

        public bool Pendiente { get; set; }
        public bool Aprobado { get; set; }

        public int SiniestroId { get; set; }
        public Siniestro Siniestro { get; set; }

        public string Detalle { get; set; }
        public DateTime? FechaVisado { get; set; }


        [ForeignKey("Solicitante")]
        public int? SolicitanteId { get; set; }
        public Usuario Solicitante { get; set; }


        [ForeignKey("Visador")]
        public int? VisadorId { get; set; }
        public Usuario Visador { get; set; }
    }
}
