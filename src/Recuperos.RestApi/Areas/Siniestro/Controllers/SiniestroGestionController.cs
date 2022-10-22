using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Commands;
using Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Queries.CamposEnCambioEstado;
using Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Queries.InicializacionSiniestro;

namespace Recuperos.RestApi.Areas.Siniestro.Controllers
{
    [Authorize]
    [RoutePrefix("api/siniestros/{id}/gestion")]
    public class SiniestroGestionController : ApiController
    {
        private readonly IMediator _mediator;

        public SiniestroGestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("inicio")]
        public async Task<SiniestroObtenidoGestionViewModel> Get(int id)
        {
            return await _mediator.Send(new GestionSiniestroQuery() { Id = id });
        }

        [HttpGet]
        [Route("permisosParaEstado/{estadoId}")]
        public async Task<PermisosObtenidosViewModel> GetPermisosParaEstado(int id, int estadoId)
        {
            return await _mediator.Send(new CamposEnCambioEstadoQuery() { Id = id, EstadoId = estadoId });
        }

        [HttpPut]
        [Route("guardar")]
        public async Task<List<string>> Put([FromUri] int id, [FromBody] GestionSiniestroCommand command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}
