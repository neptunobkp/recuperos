using System.Security.Principal;
using System.Web;

namespace Recuperos.RestApi.Infraestructura.Seguridad
{
    public class HttpContextPrincipal : IPrincipal
    {
        public IIdentity Identity
        {
            get { return HttpContext.Current.User?.Identity; }
        }

        public bool IsInRole(string role)
        {
            return HttpContext.Current.User.IsInRole(role);
        }
    }
}