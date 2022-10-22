using System.Collections.Generic;

namespace Recuperos.Aplicacion.Funciones.Estados.Transiciones.Queries.Listar
{
    public class NodoTransicionDto
    {
        public NodoTransicionDto()
        {
            Items = new List<ItemTransicionDto>();
        }

        public string Nombre { get; set; }
        public List<ItemTransicionDto> Items { get; set; }
    }
}
