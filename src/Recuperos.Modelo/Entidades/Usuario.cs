using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recuperos.Modelo.Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            SolicitudesSolictante = new List<SolicitudVisto>();
            SolicitudesVisador = new List<SolicitudVisto>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string NombreIngreso { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public string Rut { get; set; }


        [InverseProperty("Solicitante")]
        public ICollection<SolicitudVisto> SolicitudesSolictante { get; set; }

        [InverseProperty("Visador")]
        public ICollection<SolicitudVisto> SolicitudesVisador { get; set; }
    }
}