using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Commands.Asignar;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Commands.Visar;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ConsultaAsignado;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ObtenerSiniestro;

namespace Recuperos.RestApi.Areas.Siniestro.Controllers
{
    [Authorize]
    [RoutePrefix("api/siniestros/{siniestroId}")]
    public class SiniestrosController : ApiController
    {
        private readonly IMediator _mediator;
        public SiniestrosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<SiniestroObtenidoViewModel> Get(int siniestroId)
        {
            return await _mediator.Send(new ObtenerSiniestroQuery { SiniestroId = siniestroId });
        }

      

        [HttpPut]
        [Route("Asignar")]
        public async Task<Unit> PutAsignar(int siniestroId, [FromBody] AsignarCommand command)
        {
            command.SiniestroId = siniestroId;
            return await _mediator.Send(command);
        }

        [HttpPut]
        [Route("VisarAceptar")]
        public async Task<Unit> PutAceptar(int siniestroId)
        {
            return await _mediator.Send(new VisarSiniestroCommand { Id = siniestroId, Aceptado = true });
        }

        [HttpPut]
        [Route("VisarRechazar")]
        public async Task<Unit> PutRechazar(int siniestroId, [FromBody] RechazoVisadoCommandViewModel motivo)
        {
            return await _mediator.Send(new VisarSiniestroCommand { Id = siniestroId, Motivo = motivo });
        }
    }
}
