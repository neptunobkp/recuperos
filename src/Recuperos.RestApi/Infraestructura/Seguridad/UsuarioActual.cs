using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Recuperos.Aplicacion.Interfaces.Autorizacion;

namespace Recuperos.RestApi.Infraestructura.Seguridad
{
    public class UsuarioActual : IUsuarioActualService
    {
        public UsuarioActual(HttpContextPrincipal accesor)
        {
            var identityClaims = (ClaimsIdentity)accesor.Identity;
            if (identityClaims == null) return;
             Id = identityClaims.GetUserId<int>();
            Nombres = identityClaims.GetUserName();
            Rol = identityClaims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Rol { get; set; }
    }
}