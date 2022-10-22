using System;
using System.Configuration;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.Equifax;
using Recuperos.RestApi.Infraestructura.HttpClients;
using Recuperos.Servicios.ConsultaDicom;
using Recuperos.Servicios.ConsultaDicom.Mocks;
using Recuperos.Servicios.Equifax.Mocks;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura.StartupExtensions
{
    public static class ConfiguradorConsultaDicom
    {
        public static Container AddConsultaDicom(this Container container)
        {

            if (string.Compare(ConfigurationManager.AppSettings["ConsultaDicom.Api.Deshabilitado"], "true",
                StringComparison.InvariantCultureIgnoreCase) == 0)
                container.Register<IApiConsultaDicom, MockApiConsultaDicom>(Lifestyle.Scoped);
            else
            {
                container.Register<IConsultaDicomHttpClientAccessor, ConsultaDicomHttpClientAccessor>(Lifestyle.Singleton);
                container.Register<IApiConsultaDicom, ApiConsultaDicom>(Lifestyle.Scoped);
            }
            return container;
        }
    }
}