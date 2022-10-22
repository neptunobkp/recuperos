using System.Collections.Generic;
using MediatR;
using Recuperos.Aplicacion.Models;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Observaciones.Queries.ObtenerTiposObervacion
{
    public class ObtenerTiposObervacionQuery : IRequest<IEnumerable<ItemLista>>
    {
    }
}
