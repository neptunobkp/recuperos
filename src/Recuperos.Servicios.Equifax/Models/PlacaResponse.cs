

// ReSharper disable InconsistentNaming

namespace Recuperos.Servicios.Equifax.Models
{
    public class PlacaResponse
    {
        public PlacaResponse()
        {
            PropietarioDTO = new PropietarioResponse();
        }

        public string descTipo { get; set; }
        public string descMarca { get; set; }
        public string descModelo { get; set; }
        public string numeroMotor { get; set; }
        public string numeroChasis { get; set; }
        public string anoFab { get; set; }
        public string descColor { get; set; }
        public PropietarioResponse PropietarioDTO { get; set; }
    }

    public class PropietarioResponse
    {
        public string rutDueno { get; set; }
        public string nombreDueno { get; set; }
    }
}
