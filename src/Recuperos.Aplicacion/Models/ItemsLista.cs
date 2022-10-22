using System.Collections.Generic;

namespace Recuperos.Aplicacion.Models
{
    public class ItemsLista
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public List<ItemLista> Items { get; set; }
    }
}