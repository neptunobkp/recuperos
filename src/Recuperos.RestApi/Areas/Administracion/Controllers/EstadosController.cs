using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Estados.Commands.CrearEstado;
using Recuperos.Aplicacion.Funciones.Estados.Commands.EditarEstado;
using Recuperos.Aplicacion.Funciones.Estados.Commands.EliminarEstado;
using Recuperos.Aplicacion.Funciones.Estados.Queries.ListarEstados;
using Recuperos.Aplicacion.Funciones.Estados.Queries.ObtenerEstado;
using Recuperos.Aplicacion.Models;

namespace Recuperos.RestApi.Areas.Administracion.Controllers
{
    [Authorize]
    [RoutePrefix("api/etapas/{etapaId}")]
    public class EstadosController : ApiController
    {
        private readonly IMediator _mediator;
        public EstadosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("estados/{id}")]
        public async Task<ItemLista> Get(int etapaId, int id)
        {
            return await _mediator.Send(new ObtenerEstadoQuery{ Id = id });
        }

        [Route("estados")]
        public async Task<IEnumerable<ItemLista>> Get(int etapaId)
        {
            return await _mediator.Send(new ListarEstadosQuery { EtapaId = etapaId });
        }
        [Route("estados")]
        public async Task<int> Post([FromBody] CrearEstadoCommand command)
        {
            return await _mediator.Send(command);
        }
        [Route("estados")]
        public async Task<Unit> Put([FromBody] EditarEstadoCommand command)
        {
            return await _mediator.Send(command);
        }
        [Route("estados")]
        public async Task<Unit> Delete([FromUri] EliminarEstadoCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
