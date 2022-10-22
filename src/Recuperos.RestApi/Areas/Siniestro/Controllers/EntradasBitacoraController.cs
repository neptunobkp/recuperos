using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Bitacora.Queries.ObtenerBitacoraSiniestro;

namespace Recuperos.RestApi.Areas.Siniestro.Controllers
{
    [Authorize]
    public class EntradasBitacoraController : ApiController
    {
        private readonly IMediator _mediator;

        public EntradasBitacoraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<BitacoraResponseViewModel> Post([FromBody] ObtenerBitacoraSiniestroQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
