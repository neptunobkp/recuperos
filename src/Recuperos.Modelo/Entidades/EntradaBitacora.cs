using System;

namespace Recuperos.Modelo.Entidades
{
   public class EntradaBitacora
    {
        public EntradaBitacora()
        {
            Fecha = DateTime.Now;
            Hora = $"{DateTime.Now.Hour.ToString().PadLeft(2, '0')}:{DateTime.Now.Minute.ToString().PadLeft(2, '0')}";
        }

        public EntradaBitacora(int siniestroId, int usuarioId, int tipoBitacoraId, string detalle) : this()
        {
            SiniestroId = siniestroId;
            UsuarioId = usuarioId;
            TipoBitacoraId = tipoBitacoraId;
            Detalle = detalle;
        }


        public int Id { get; set; }
        public int SiniestroId { get; set; }
        public Siniestro Siniestro { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime Fecha { get; set; }
        public string Hora { get; set; }

        public int TipoBitacoraId { get; set; }
        public TipoBitacora TipoBitacora { get; set; }

        public string Detalle { get; set; }
    }
}
