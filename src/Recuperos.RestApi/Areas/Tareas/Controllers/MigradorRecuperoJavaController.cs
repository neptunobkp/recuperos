using System;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Servicios.Migracion.Commands.Migrar;

namespace Recuperos.RestApi.Areas.Tareas.Controllers
{
    [Authorize]
    public class MigradorRecuperoJavaController : ApiController
    {
        private readonly IMediator _mediator;
        public MigradorRecuperoJavaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ResultadoMigracion> Get()
        {

            return await _mediator.Send(new MigrarCommand()
            {
                Desde = new DateTime(2019, 2, 1),
                Hasta = new DateTime(2019, 2, 10)
            });
        }
    }
}
