
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Recuperos.Aplicacion.Funciones.Usuarios.Queries.AutenticarUsuarioQuery;

namespace Recuperos.RestApi.Areas.Publico.Controllers
{
    public class AnonimoController : ApiController
    {
        public UsuarioViewModel Get()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;

            return new UsuarioViewModel
            {
                Id = identityClaims.GetUserId<int>(),
                Nombres = identityClaims.GetUserName(),
                Rol = identityClaims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
            };
        }
    }
}
