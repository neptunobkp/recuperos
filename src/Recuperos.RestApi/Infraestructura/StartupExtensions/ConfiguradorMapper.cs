using Recuperos.RestApi.Infraestructura.Automapper;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura.StartupExtensions
{
    public static class ConfiguradorMapper
    {
        public static Container AddMapper(this Container container)
        {
            container.RegisterSingleton(() => GetMapper(container));
            return container;
        }

        private static AutoMapper.IMapper GetMapper(Container container)
        {
            var mp = container.GetInstance<MapperProvider>();
            return mp.GetMapper();
        }
    }
}