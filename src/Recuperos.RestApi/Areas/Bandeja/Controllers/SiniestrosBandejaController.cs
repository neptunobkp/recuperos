using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestros;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario;

namespace Recuperos.RestApi.Areas.Bandeja.Controllers
{
    [RoutePrefix("api/SiniestrosBandeja")]
    public class SiniestrosBandejaController : ApiController
    {
        private readonly IMediator _mediator;
        public SiniestrosBandejaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Filtrar")]
        public async Task<FilasSiniestroViewModel> Post( [FromBody] ListarSiniestrosQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
