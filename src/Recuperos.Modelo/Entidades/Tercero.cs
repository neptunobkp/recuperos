namespace Recuperos.Modelo.Entidades
{
    public class Tercero
    {
        public int Id { get; set; }

        public int SiniestroId { get; set; }
        public Siniestro Siniestro { get; set; }

        public string Nombres { get; set; }
        public int Rut { get; set; }

        public string Direccion { get; set; }
        public string DireccionAlt { get; set; }
        public string Correo { get; set; }
        public string CorreoAlt { get; set; }
        public string Telefono { get; set; }
        public string TelefonoAlt { get; set; }
        public string Alias { get; set; }
        public int? Clasificacion { get; set; }
        public int? Culpabilidad { get; set; }
        public bool EsPrincipal { get; set; }

        public virtual TerceroVehiculo Vehiculo { get; set; }


    }
}