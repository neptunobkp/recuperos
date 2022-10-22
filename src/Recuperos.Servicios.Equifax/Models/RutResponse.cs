using System.Collections.Generic;
using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace Recuperos.Servicios.Equifax.Models
{
    public class RutResponse
    {
        public string rut { get; set; }
        public string nombre { get; set; }

        [XmlElement("VehiculoDTO")]
        public List<VehiculoResponse> vehiculos { get; set; }
    }

    public class VehiculoResponse
    {
        public string placa { get; set; }
        public string descTipo { get; set; }
        public string descMarca { get; set; }
        public string descModelo { get; set; }
        public string numeroMotor { get; set; }
        public string numeroChasis { get; set; }
        public string anoFab { get; set; }
        public string descColor { get; set; }
    }
}
