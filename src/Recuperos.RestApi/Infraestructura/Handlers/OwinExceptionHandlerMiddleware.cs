using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Owin;
using Newtonsoft.Json;
using NLog;

namespace Recuperos.RestApi.Infraestructura.Handlers
{
    public class OwinExceptionHandlerMiddleware
    {
        private static readonly Logger Nlog = LogManager.GetCurrentClassLogger();

        private readonly Func<IDictionary<string, object>, Task> _next;

        public OwinExceptionHandlerMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            if (next == null)
            {
                throw new ArgumentNullException("next");
            }
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            try
            {
                await _next(environment);
            }
            catch (Exception ex)
            {
                try
                {
                    var owinContext = new OwinContext(environment);
                    HandleException(ex, owinContext);

                    return;
                }
                catch (Exception)
                {
                    // If there's a Exception while generating the error page, re-throw the original exception.
                }
                throw;
            }
        }
        private void HandleException(Exception ex, IOwinContext context)
        {
            Nlog.Fatal(ex, "startup");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ReasonPhrase = "Internal Server Error";
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(ex));

        }

    }
}