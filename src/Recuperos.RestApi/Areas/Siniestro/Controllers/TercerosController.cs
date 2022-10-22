using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Commands.Agregar;
using Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Commands.Editar;
using Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Commands.Eliminar;
using Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.Listar;
using Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.Obtener;

namespace Recuperos.RestApi.Areas.Siniestro.Controllers
{
    [Authorize]
    [RoutePrefix("api/siniestros/{siniestroId}")]
    public class TercerosController : ApiController
    {
        private readonly IMediator _mediator;
        public TercerosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("terceros/crear")]
        [HttpPost]
        public async Task<int> Post(int siniestroId, [FromBody] AgregarTerceroCommand command)
        {
            command.SiniestroId = siniestroId;
            return await _mediator.Send(command);
        }

        [Route("terceros/listar")]
        [HttpPost]
        public async Task<PaginaListableTerceroViewModel> Get(int siniestroId, [FromBody] ListarTercerosQuery query)
        {
            query.SiniestroId = siniestroId;
            return await _mediator.Send(query);
        }

        [Route("terceros/{id}")]
        [HttpGet]
        public async Task<TerceroViewModel> Get(int siniestroId, int id)
        {
            return await _mediator.Send(new ObtenerTerceroQuery() { Id = id });
        }

        [Route("terceros/{id}")]
        [HttpDelete]
        public async Task<Unit> Delete(int siniestroId, int id)
        {
            return await _mediator.Send(new EliminarTerceroCommand { Id = id });
        }


        [Route("terceros/editar")]
        [HttpPut]
        public async Task<Unit> Put(int siniestroId, [FromBody] EditarTerceroCommand command)
        {
            return await _mediator.Send(command);
        }
          
    }
}
