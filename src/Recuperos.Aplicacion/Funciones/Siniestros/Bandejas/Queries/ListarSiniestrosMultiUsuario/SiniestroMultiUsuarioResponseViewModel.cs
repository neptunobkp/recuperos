using System.Collections.Generic;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario
{
    public class SiniestroMultiUsuarioResponseViewModel
    {
        
        public List<SiniestroMultiUsuarioViewModel> Items { get; set; }
        public int Total { get; set; }
        public int TotalGlobal { get; set; }
    }
}
