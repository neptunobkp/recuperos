using System.Collections.Generic;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosVisables
{
    public class SiniestroVisablesResponseViewModel
    {
        public List<SiniestroVisablesViewModel> Items { get; set; }
        public int Total { get; set; }
    }
}
