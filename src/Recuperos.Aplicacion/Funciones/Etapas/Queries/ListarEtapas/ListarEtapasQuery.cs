using System.Collections.Generic;
using MediatR;
using Recuperos.Aplicacion.Models;

namespace Recuperos.Aplicacion.Funciones.Etapas.Queries.ListarEtapas
{
   public  class ListarEtapasQuery : IRequest<IEnumerable<ItemLista>>
    {
    }
}
