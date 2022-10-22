using FluentValidation;
using Recuperos.Aplicacion.Comun.Comportamientos;
using Recuperos.Aplicacion.Funciones.Estados.Queries.ListarEstados;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura.StartupExtensions
{
    public static class ConfiguradorValidador
    {
        public static Container AddValidador(this Container container)
        {
            container.Register<IValidator<ListarEstadosQuery>, ListarEstadosQueryValidator>();

            var assemblies = new[] { typeof(ValidateNada<>).Assembly };
            container.Collection.Register(typeof(IValidator<>), assemblies);

            return container;
        }
    }
}