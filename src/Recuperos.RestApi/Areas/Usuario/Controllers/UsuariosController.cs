using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Usuarios.Queries.ListarUsuariosPorPerfil;
using Recuperos.Aplicacion.Models;

namespace Recuperos.RestApi.Areas.Usuario.Controllers
{
    [Authorize]
    public class UsuariosController : ApiController
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<ItemLista>> Get([FromUri] ListarUsuariosPorPerfilQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
