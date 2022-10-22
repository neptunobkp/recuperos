using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace Recuperos.Persistencia.Configuraciones
{

    public static class ModelBuilderExtensions
    {
        public static void ApplyAllConfigurations(this DbModelBuilder modelBuilder, Assembly assembly)
        {
            var typesToRegister = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.Name == nameof(IConfiguracionable)))
                .ToList();


            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }
    }
}
