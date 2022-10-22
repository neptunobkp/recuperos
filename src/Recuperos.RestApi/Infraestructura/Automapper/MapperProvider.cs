using AutoMapper;
using Recuperos.Aplicacion.Comun.Automapper;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura.Automapper
{

    public class MapperProvider
    {
        private readonly Container _container;

        public MapperProvider(Container container)
        {
            _container = container;
        }

        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
                cfg.ConstructServicesUsing(_container.GetInstance);
            });
            IMapper mapper = new Mapper(config);
            return mapper;
        }
    }
}