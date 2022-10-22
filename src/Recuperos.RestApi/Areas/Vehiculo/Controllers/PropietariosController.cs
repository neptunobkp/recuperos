using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.BuscarRut;

namespace Recuperos.RestApi.Areas.Vehiculo.Controllers
{
    [Authorize]
    public class PropietariosController : ApiController
    {
        private readonly IMediator _mediator;

        public PropietariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<RutResultViewModel> Buscar(int rut)
        {
            return await _mediator.Send(new BuscarRutQuery() { Rut = rut });
        }
    }
}
