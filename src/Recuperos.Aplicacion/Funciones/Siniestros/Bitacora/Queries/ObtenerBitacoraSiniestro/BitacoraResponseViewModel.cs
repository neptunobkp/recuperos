using System.Collections.Generic;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bitacora.Queries.ObtenerBitacoraSiniestro
{
    public class BitacoraResponseViewModel
    {
        public List<BitacoraViewModel> Items { get; set; }
        public int Total { get; set; }
    }
}
