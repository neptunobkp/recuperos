using System.Collections.Generic;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.Listar
{
    public class PaginaListableTerceroViewModel
    {
        public PaginaListableTerceroViewModel()
        {
            Items = new List<ItemListableTerceroViewModel>();
        }

        public List<ItemListableTerceroViewModel> Items { get; set; }
        public int Total { get; set; }
    }
}
