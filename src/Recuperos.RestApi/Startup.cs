using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;
using Recuperos.RestApi.Infraestructura.Filtros;
using Recuperos.RestApi.Infraestructura.Handlers;
using Recuperos.RestApi.Infraestructura.StartupExtensions;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

[assembly: OwinStartup(typeof(Recuperos.RestApi.Startup))]
namespace Recuperos.RestApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigurarDependencias(app);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalFilters.Filters.Add(new ClientActionFilterAttribute());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            SwaggerConfig.Register(GlobalConfiguration.Configuration);
        }

        public void ConfigurarDependencias(IAppBuilder app)
        {
            var container = new Container();
            container
            .AddInjectorOpt(app)
            .AddDatabase()
            .AddEquifax()
            .AddConsultaDicom()
            .AddContentManager()
            .AddApiP02()
            .AddRnvmLocal()
            .AddInfraestructuras()
            .AddValidador()
            .AddMapper()
            .AddMediador()
            .AddAutorizacion()
            .AddWebApi(GlobalConfiguration.Configuration)
            .Verify();

            app.UseOwinExceptionHandler();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            ConfiguradorWebApi.ConfigurarAuth(app);
        }
    }
}
