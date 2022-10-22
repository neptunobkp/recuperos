using System.Security.Principal;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.RestApi.Infraestructura.Seguridad;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura.StartupExtensions
{
    public static class ConfiguradorAuth
    {
        public static Container AddAutorizacion(this Container container)
        {
            container.Register<IUsuarioActualService, UsuarioActual>(Lifestyle.Transient);
            container.RegisterSingleton<IPrincipal>(() => new HttpContextPrincipal());
            return container;
        }
    }
}