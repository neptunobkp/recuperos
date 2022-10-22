using System.Collections.Generic;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMonoUsuario
{
    public class SiniestroMonoUsuarioResponseViewModel
    {
        public List<SiniestroMonoUsuarioViewModel> Items { get; set; }
        public int Total { get; set; }
        public int TotalGlobal { get; set; }
    }
}
