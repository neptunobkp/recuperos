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
    [RoutePrefix("api/siniestro")]
    public class SiniestroController : ApiController
    {
        private readonly IMediator _mediator;
        public SiniestroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("consulta-asignacion")]
        public async Task<SiniestroAsignadoViewModel> GetAsignacion(int numero)
        {
            return await _mediator.Send(new ConsultaAsignadoQuery { Numero = numero });
        }
    }
}
