using Owin;

namespace Recuperos.RestApi.Infraestructura.Handlers
{
    public static class OwinExceptionHandlerMiddlewareAppBuilderExtensions
    {
        public static void UseOwinExceptionHandler(this IAppBuilder app)
        {
            app.Use<OwinExceptionHandlerMiddleware>();
        }
    }
}