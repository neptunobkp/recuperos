using System.Collections.Generic;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Observaciones.Queries.ObtenerObservacionesSiniestro
{
    public class ObservacionesResponseViewModel
    {
        public List<ObservacionViewModel> Items { get; set; }
        public int Total { get; set; }
    }
}
