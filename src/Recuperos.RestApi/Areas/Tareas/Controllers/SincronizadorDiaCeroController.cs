using System;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Commands.Sincronizar;

namespace Recuperos.RestApi.Areas.Tareas.Controllers
{
    [Authorize]
    public class SincronizadorDiaCeroController : ApiController
    {
        private readonly IMediator _mediator;
        public SincronizadorDiaCeroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<int> Get(int anioDesde, int mesDesde, int diaDesde, int anioHasta, int mesHasta, int diaHasta)
        {

            return await _mediator.Send(new SincronizarCommand
            {
                Desde = new DateTime(anioDesde, mesDesde, diaDesde),
                Hasta = new DateTime(anioHasta, mesHasta, diaHasta)
            });
        }
    }
}
