using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Servicios.Equifax.BuscarRutEquifax;
using Recuperos.Aplicacion.Funciones.Servicios.Equifax.BuscarVehiculoEquifax;

namespace Recuperos.RestApi.Areas.Servicios.Controllers
{
    [Authorize]
    [RoutePrefix("api/equifax")]
    public class ApiEquifaxController : ApiController
    {
        private readonly IMediator _mediator;

        public ApiEquifaxController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("buscarPatente")]
        public async Task<ResultadoPorPatenteEquifaxViewModel> BuscarVehiculo(string patente, int siniestroId)
        {
            return await _mediator.Send(new BuscarVehiculoEquifaxQuery { Patente = patente, SiniestroId = siniestroId });
        }

        [HttpGet]
        [Route("buscarRut")]
        public async Task<RutResultEquifaxViewModel> BuscarPersona(int rut, int siniestroId)
        {
            return await _mediator.Send(new BuscarRutEquifaxQuery() { Rut = rut, SiniestroId = siniestroId });
        }
    }
}
