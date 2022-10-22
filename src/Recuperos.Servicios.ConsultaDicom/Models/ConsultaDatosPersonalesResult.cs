namespace Recuperos.Servicios.ConsultaDicom.Models
{
    public class ConsultaDatosPersonalesResult
    {
        public string Rut { get; set; }
        public string Dv { get; set; }
        public string Nombre { get; set; }
        public Direccion[] Direcciones { get; set; }
        public Telefono[] Telefonos { get; set; }
        public string[] Correos { get; set; }
    }
}