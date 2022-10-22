namespace Recuperos.Servicios.ConsultaDicom.Models
{
    public class Direccion
    {
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string DireccionVerificada { get; set; }
        public string TipoDomicilio { get; set; }
        public string Fecha { get; set; }
        public string Referencia { get; set; }
        public DatosPersonalesResultDireccionComuna Comuna { get; set; }
        public DatosPersonalesResultDireccionRegion Region { get; set; }
    }
}