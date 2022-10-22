namespace Recuperos.Aplicacion.Interfaces.Servicios.RnvmLocal.Models
{
    public class Propietario
    {
        public string ApellidoMaterno { get; set; }
        public string ApellidoPaterno { get; set; }

        public string Nombre { get; set; }
        public int? Rut { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Direccion Direccion { get; set; }

    }
}