using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Observaciones.Queries.ObtenerTiposObervacion;
using Recuperos.Aplicacion.Models;

namespace Recuperos.RestApi.Areas.Parametros.Controllers
{
    [Authorize]
    public class TiposObservacionController : ApiController
    {
        private readonly IMediator _mediator;
        public TiposObservacionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<ItemLista>> Get()
        {
            return await _mediator.Send(new ObtenerTiposObervacionQuery());
        }

        
    }
}
