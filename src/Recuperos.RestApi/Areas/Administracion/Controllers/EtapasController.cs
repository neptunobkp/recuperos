
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Etapas.Commands.CrearEtapa;
using Recuperos.Aplicacion.Funciones.Etapas.Commands.EditarEtapa;
using Recuperos.Aplicacion.Funciones.Etapas.Commands.EliminarEtapa;
using Recuperos.Aplicacion.Funciones.Etapas.Queries.ListarEtapas;
using Recuperos.Aplicacion.Funciones.Etapas.Queries.ObtenerEtapa;
using Recuperos.Aplicacion.Models;

namespace Recuperos.RestApi.Areas.Administracion.Controllers
{
    public class EtapasController : ApiController
    {
        private readonly IMediator _mediator;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public EtapasController(IMediator mediator)
        {
            Logger.Info("Llamo a etapas");
            _mediator = mediator;
        }

        public async Task<ItemLista> Get(int id)
        {
            return await _mediator.Send(new ObtenerEtapaQuery { Id = id });
        }
        public async Task<IEnumerable<ItemLista>> Get()
        {
            return await _mediator.Send(new ListarEtapasQuery());
        }

        public async Task<int> Post([FromBody] CrearEtapaCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<Unit> Put([FromBody] EditarEtapaCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<Unit> Delete([FromUri] EliminarEtapaCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
