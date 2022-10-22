using System;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Servicios.Migracion.Commands.Migrar;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Commands.Utiles;

namespace Recuperos.RestApi.Areas.Misc.Controllers
{
    [RoutePrefix("api/version")]
    public class VersionController : ApiController
    {
        private readonly IMediator _mediator;

        public VersionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("")]
        [HttpGet]
        public string Get()
        {
            var hoy = DateTime.Now;
            return $"01.07.09 {hoy.ToShortTimeString()}" ;
        }

        [Route("utiles")]
        [HttpPost]
        public async Task<Unit> Procesar([FromBody] UtilesSiniestroCommand command)
        {
            return await _mediator.Send(command);
        }

        [Route("importacion")]
        [HttpPost]
        public async Task<ResultadoMigracion> Procesar([FromBody] UtilesMigraSiniestroCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}