using Owin;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Recuperos.RestApi.Infraestructura.StartupExtensions
{
    public static class ConfiguradorInjector
    {
        public static Container AddInjectorOpt(this Container container, IAppBuilder app)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            app.Use(async (context, next) => { using (AsyncScopedLifestyle.BeginScope(container)) { await next(); } });
            return container;
        }
    }
}