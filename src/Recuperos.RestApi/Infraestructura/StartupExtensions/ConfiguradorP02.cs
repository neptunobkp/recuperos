using System;
using System.Configuration;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;
using Recuperos.RestApi.Infraestructura.HttpClients;
using Recuperos.Servicios.Recup02;
using Recuperos.Servicios.Recup02.Mocks;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura.StartupExtensions
{
    public static class ConfiguradorP02
    {
        public static Container AddApiP02(this Container container)
        {
            if (string.Compare(ConfigurationManager.AppSettings["Recup02.Api.Deshabilitado"], "true",
                StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                container.Register<IApiRecup02, ApiRecup02Mock>(Lifestyle.Scoped);
                container.Register<IApiMigracion, ApiMigracionMock>(Lifestyle.Scoped);
            }
            else
            {
                container.Register<IRecup02HttpClientAccessor, Recup02HttpClientAccessor>(Lifestyle.Singleton);
                container.Register<IApiMigracion, ApiMigracion>(Lifestyle.Scoped);
                container.Register<IApiRecup02, ApiRecup02>(Lifestyle.Scoped);
            }

            return container;
        }
    }
}