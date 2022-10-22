using System.Web.Http;
using Swashbuckle.Application;

namespace Recuperos.RestApi
{
    public static class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Api Recuperos Bci Seguros");
                    c.ApiKey("Authorization")
                        .Description("Token")
                        .Name("Bearer")
                        .In("header");
                })
                .EnableSwaggerUi(c =>
                {
                    c.EnableApiKeySupport("Authorization", "header");
                });
        }
    }
}