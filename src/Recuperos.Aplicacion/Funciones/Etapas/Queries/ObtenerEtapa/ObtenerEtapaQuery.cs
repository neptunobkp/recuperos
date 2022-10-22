using MediatR;
using Recuperos.Aplicacion.Models;

namespace Recuperos.Aplicacion.Funciones.Etapas.Queries.ObtenerEtapa
{
    public class ObtenerEtapaQuery : IRequest<ItemLista>
    {
        public int Id { get; set; }


    }
}
