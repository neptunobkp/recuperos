using System.Xml.Serialization;

namespace Recuperos.Servicios.ConsultaDicom.Models
{
    public class DatosPersonalesResultCorreo
    {
        [XmlElement("string")]
        public string Correo { get; set; }
    }
}