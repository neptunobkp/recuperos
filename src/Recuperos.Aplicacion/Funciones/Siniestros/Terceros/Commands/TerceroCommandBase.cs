using System.Security.AccessControl;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Commands
{
   public class TerceroCommandBase
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public int? Anio { get; set; }
        public int? Clasificacion { get; set; }
        public string Color { get; set; }
        public string Correo { get; set; }
        public string CorreoAlt { get; set; }
        public int? Culpabilidad { get; set; }
        public string Direccion { get; set; }
        public bool EsPrincipal { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Nombres { get; set; }
        public string NumeroChasis { get; set; }
        public string NumeroMotor { get; set; }
        public string Patente { get; set; }
        public int Rut { get; set; }
        public string Telefono { get; set; }
        public string TelefonoAlt { get; set; }
    }
}
