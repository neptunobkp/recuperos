using Recuperos.Aplicacion.Interfaces.Exportacion;
using Recuperos.Servicios.Exportador.Excel;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura.StartupExtensions
{
    public static class ConfiguradorInfraestructuras
    {
        public static Container AddInfraestructuras(this Container container)
        {
            container.Register<IExportadorExcel, ExportadorExcel>(Lifestyle.Scoped);
            return container;
        }
    }
}