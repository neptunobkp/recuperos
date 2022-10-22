using System;
using System.Configuration;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.ContentManager;
using Recuperos.RestApi.Infraestructura.HttpClients;
using Recuperos.Servicios.ContentManager;
using Recuperos.Servicios.ContentManager.Mocks;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura.StartupExtensions
{
    public static class ConfiguradorContentManager
    {
        public static Container AddContentManager(this Container container)
        {
            if (string.Compare(ConfigurationManager.AppSettings["ViewCM.Api.Deshabilitado"], "true",
                StringComparison.InvariantCultureIgnoreCase) == 0)
                container.Register<IApiContentManager, ApiContentManagerMock>(Lifestyle.Scoped);
            else
            {
                container.Register<IContentManagerHttpClientAccessor, ContentManagerHttpClientAccessor>(Lifestyle.Singleton);
                container.Register<IApiContentManager, ApiContentManager>(Lifestyle.Scoped);
            }
            return container;
        }
    }
}