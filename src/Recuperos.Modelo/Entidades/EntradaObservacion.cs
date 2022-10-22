using System;

namespace Recuperos.Modelo.Entidades
{
    public class EntradaObservacion
    {
        public int Id { get; set; }

        public int SiniestroId { get; set; }
        public Siniestro Siniestro { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime Fecha { get; set; }
        public string Hora { get; set; }

        public int TipoObservacionId { get; set; }
        public TipoObservacion TipoObservacion { get; set; }

        public string Detalle { get; set; }
    }
}
