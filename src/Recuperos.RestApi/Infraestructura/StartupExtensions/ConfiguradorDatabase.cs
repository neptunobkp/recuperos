using System;
using System.Configuration;
using Recuperos.Aplicacion.Interfaces;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura.StartupExtensions
{
    public static class ConfiguradorDatabase
    {
        public static Container AddDatabase(this Container container)
        {
            if (string.Compare(ConfigurationManager.AppSettings["App.Persistencia"], "SqlServer",
                StringComparison.InvariantCultureIgnoreCase) == 0)
                container.Register<IGenerateDbContext, Persistencia.GenerateAppDbContext>(Lifestyle.Scoped);
            else
                container.Register<IGenerateDbContext, Persistencia.BaseOracle.GenerateAppDbContext>(Lifestyle.Scoped);
            return container;
        }
    }
}