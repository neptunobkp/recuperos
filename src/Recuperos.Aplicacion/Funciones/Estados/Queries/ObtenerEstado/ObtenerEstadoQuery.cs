using MediatR;
using Recuperos.Aplicacion.Models;

namespace Recuperos.Aplicacion.Funciones.Estados.Queries.ObtenerEstado
{
    public class ObtenerEstadoQuery : IRequest<ItemLista>
    {
        public int Id { get; set; }
    }
}
