using System.Collections.Generic;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetFacturas
{
    public class FacturasResponseViewModel
    {
        public FacturasResponseViewModel()
        {
            Items = new List<FacturaViewModel>();
        }

        public string UrlBase { get; set; }
        public List<FacturaViewModel> Items { get; set; }
    }
}
