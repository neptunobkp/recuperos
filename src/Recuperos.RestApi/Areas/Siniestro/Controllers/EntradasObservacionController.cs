using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Observaciones.Commands.Agregar;
using Recuperos.Aplicacion.Funciones.Siniestros.Observaciones.Queries.ObtenerObservacionesSiniestro;

namespace Recuperos.RestApi.Areas.Siniestro.Controllers
{
    [Authorize]
    [RoutePrefix("api/siniestros/{id}/EntradasObservacion")]
    public class EntradasObservacionController : ApiController
    {
        private readonly IMediator _mediator;

        public EntradasObservacionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("filtrar")]
        public async Task<ObservacionesResponseViewModel> Post([FromUri] int id, [FromBody] ObtenerObservacionesSiniestroQuery query)
        {
            query.SiniestroId = id;
            return await _mediator.Send(query);
        }

        [HttpPost]
        [Route("crear")]
        public async Task<Unit> Post([FromUri] int id, [FromBody] AgregarObservacionCommand command)
        {
            command.SiniestroId = id;
            return await _mediator.Send(command);
        }
    }
}
