using System;
using System.Configuration;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.Equifax;
using Recuperos.RestApi.Infraestructura.HttpClients;
using Recuperos.Servicios.Equifax;
using Recuperos.Servicios.Equifax.Mocks;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura.StartupExtensions
{
    public static class ConfiguradorEquifax
    {
        public static Container AddEquifax(this Container container)
        {
            if (string.Compare(ConfigurationManager.AppSettings["Equifax.Api.Deshabilitado"], "true",
                StringComparison.InvariantCultureIgnoreCase) == 0)
                container.Register<IApiEquifax, ApiEquifaxMock>(Lifestyle.Scoped);
            else
            {
                container.Register<IEquifaxHttpClientAccessor, EquifaxHttpClientAccessor>(Lifestyle.Singleton);
                container.Register<IApiEquifax, ApiEquifax>(Lifestyle.Scoped);
            }
            return container;
        }
    }
}