using System.Collections.Generic;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Estados.Transiciones.Queries.Listar
{
    public class ListarTransicionesQuery : EstadoIdentificable, IRequest<List<ItemTransicionDto>>
    {
    }
}
