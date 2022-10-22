using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Cabecera.Queries;

namespace Recuperos.RestApi.Areas.Siniestro.Controllers
{
    [Authorize]
    public class SiniestroCabeceraController : ApiController
    {
        private readonly IMediator _mediator;

        public SiniestroCabeceraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<SiniestroCabeceraViewModel> Get(int id)
        {
            return await _mediator.Send(new CabeceraQuery { Id = id });
        }
    }
}
