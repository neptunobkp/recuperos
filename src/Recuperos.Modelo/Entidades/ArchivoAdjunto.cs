using System;

namespace Recuperos.Modelo.Entidades
{
   public class ArchivoAdjunto
    {
        public int Id { get; set; }
        public int SiniestroId { get; set; }
        public Siniestro Siniestro { get; set; }

        public DateTime Fecha { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public string Nombre { get; set; }
        public string Extension { get; set; }

        public string Url { get; set; }

        public bool Eliminado { get; set; }
    }
}
