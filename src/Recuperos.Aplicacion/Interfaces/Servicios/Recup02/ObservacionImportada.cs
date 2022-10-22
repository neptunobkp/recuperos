using System;

namespace Recuperos.Aplicacion.Interfaces.Servicios.Recup02
{
    public class ObservacionImportada
    {
        public decimal? Usuarioid { get; set; }
        public DateTime? Fecha { get; set; }
        public string Hora { get; set; }
        public string Detalle { get; set; }
        public string Tipoobservacionid { get; set; }
    }
}