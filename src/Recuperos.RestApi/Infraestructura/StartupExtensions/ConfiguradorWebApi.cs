using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Recuperos.RestApi.Infraestructura.Seguridad;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura.StartupExtensions
{
    public static class ConfiguradorWebApi
    {
        public static Container AddWebApi(this Container container, HttpConfiguration configuration)
        {
            container.RegisterWebApiControllers(configuration);
            return container;
        }

        public static void ConfigurarAuth(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(8),
                Provider = new AplicacionAuthServerProvider()
            };
            app.UseOAuthBearerTokens(oAuthOptions);
            app.UseOAuthAuthorizationServer(oAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}