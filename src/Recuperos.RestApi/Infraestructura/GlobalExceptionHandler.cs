using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using Newtonsoft.Json;
using NLog;
using Recuperos.Aplicacion.Comun.Exceptions;

namespace Recuperos.RestApi.Infraestructura
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        private static readonly Logger Nlog = LogManager.GetCurrentClassLogger();
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var code = HttpStatusCode.InternalServerError;
            string result;
            Nlog.Log(LogLevel.Error, context?.Exception, RequestToString(context?.Request));

            if (context?.Exception is ValidationException)
            {
                var valException = context.Exception as ValidationException;
                code = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(valException?.Failures);
            }
            else
            {
                result = JsonConvert.SerializeObject(new { error = context?.Exception.ToString() });
            }

            var response = context?.Request.CreateResponse(code, new { error = result });
            response?.Headers.Add("X-Error", "Error");
            if (context != null)
                context.Result = new ResponseMessageResult(response);
            return base.HandleAsync(context, cancellationToken);
        }

        private static string RequestToString(HttpRequestMessage request)
        {
            var message = new StringBuilder();
            if (request.Method != null)
                message.Append(request.Method);

            if (request.RequestUri != null)
                message.Append(" ").Append(request.RequestUri);

            return message.ToString();
        }
    }
}