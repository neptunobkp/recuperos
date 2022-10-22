using System;
using System.Configuration;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.RnvmLocal;
using Recuperos.RestApi.Infraestructura.HttpClients;
using Recuperos.Servicios.RnvmLocal;
using Recuperos.Servicios.RnvmLocal.Mocks;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura.StartupExtensions
{
    public static class ConfiguradorRnvm
    {
        public static Container AddRnvmLocal(this Container container)
        {
            if (string.Compare(ConfigurationManager.AppSettings["RnvmLocal.Api.Deshabilitado"], "true",
                StringComparison.InvariantCultureIgnoreCase) == 0)
                container.Register<IRnvmLocal, ApiRnvmLocalMock>(Lifestyle.Scoped);
            else
            {
                container.Register<IRnvmLocalHttpClientAccessor, RnvmLocalHttpClientAccessor>(Lifestyle.Singleton);
                container.Register<IRnvmLocal, ApiRnvmLocal>(Lifestyle.Scoped);
            }
            return container;
        }
    }
}