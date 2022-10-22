using System.Xml.Serialization;

namespace Recuperos.Servicios.ConsultaDicom.Models
{
    [XmlRoot("ConsultaVehiculoResponse", Namespace = "http://tempuri.org/")]
    public class DatosVehiculoResponse
    {
        public ConsultaVehiculoResult ConsultaVehiculoResult { get; set; }
    }
}