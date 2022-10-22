using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Recuperos.Servicios.ConsultaDicom.Models
{
    [XmlRoot("ConsultaDatosPersonalesResponse", Namespace = "http://tempuri.org/")]
    public class DatosPersonalesResponse
    {
        public ConsultaDatosPersonalesResult ConsultaDatosPersonalesResult { get; set; }
    }
}
