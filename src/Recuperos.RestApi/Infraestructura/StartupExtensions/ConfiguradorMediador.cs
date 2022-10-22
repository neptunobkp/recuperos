using System.Reflection;
using Recuperos.Aplicacion.Funciones.Etapas.Queries.ListarEtapas;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura.StartupExtensions
{
    public static class ConfiguradorMediador
    {
        public static Container AddMediador(this Container container)
        {
            container.BuildMediator(typeof(ListarEtapasQueryHandler).GetTypeInfo().Assembly);
            return container;
        }
    }
}