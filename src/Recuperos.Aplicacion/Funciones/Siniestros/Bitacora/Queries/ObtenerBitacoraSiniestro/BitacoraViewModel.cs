using System;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bitacora.Queries.ObtenerBitacoraSiniestro
{
    public class BitacoraViewModel
    {
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Tipo { get; set; }
        public string Detalle { get; set; }
    }
}
