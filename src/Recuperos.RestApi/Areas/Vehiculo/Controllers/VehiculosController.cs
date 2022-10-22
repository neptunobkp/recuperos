using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.BuscarVehiculo;

namespace Recuperos.RestApi.Areas.Vehiculo.Controllers
{
    [Authorize]
    public class VehiculosController : ApiController
    {
        private readonly IMediator _mediator;
        public VehiculosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResultadoPorPatenteViewModel> Buscar(string patente)
        {
            return await _mediator.Send(new BuscarVehiculoQuery
            { Patente = patente });
        }
    }
}
