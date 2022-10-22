using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Estados.Transiciones.Commands.CambiarCertificables;
using Recuperos.Aplicacion.Funciones.Estados.Transiciones.Commands.CrearTransicion;
using Recuperos.Aplicacion.Funciones.Estados.Transiciones.Commands.EliminarTransicion;
using Recuperos.Aplicacion.Funciones.Estados.Transiciones.Queries.Listar;
using Recuperos.Aplicacion.Funciones.Estados.Transiciones.Queries.ListarCertificables;

namespace Recuperos.RestApi.Areas.Administracion.Controllers
{
    [Authorize]
    [RoutePrefix("api/estados/{estadoId}")]
    public class TransicionesController : ApiController
    {
        private readonly IMediator _mediator;
        public TransicionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("transiciones")]
        public async Task<List<ItemTransicionDto>> Get(int estadoId)
        {
            return await _mediator.Send(new ListarTransicionesQuery() { EstadoId = estadoId });
        }

        [Route("transiciones")]
        public async Task<Unit> Post([FromBody] CrearTransicionCommand command)
        {
            return await _mediator.Send(command);
        }

        [Route("transiciones")]
        public async Task<Unit> Delete([FromUri] EliminarTransicionCommand command)
        {
            return await _mediator.Send(command);
        }

        [Route("certificables")]
        public async Task<List<ItemTransicionDto>> GetCertficables(int estadoId)
        {
            return await _mediator.Send(new ListarCertificablesQuery() { EstadoId = estadoId });
        }

        [Route("certificables")]
        public async Task<Unit> PostCertificables([FromBody] CambiarCertificablesCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
