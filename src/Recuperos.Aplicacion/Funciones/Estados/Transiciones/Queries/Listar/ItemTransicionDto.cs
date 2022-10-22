using System.Collections.Generic;

namespace Recuperos.Aplicacion.Funciones.Estados.Transiciones.Queries.Listar
{
   public class ItemTransicionDto
    {
        public string Item { get; set; }
        public List<ItemTransicionDto> Children { get; set; }
        public string Id { get; set; }
        public bool Seleccionado { get; set; }
    }
}
