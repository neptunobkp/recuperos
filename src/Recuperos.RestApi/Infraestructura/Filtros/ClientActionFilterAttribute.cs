using System.Web.Mvc;

namespace Recuperos.RestApi.Infraestructura.Filtros
{
    public class ClientActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var request = httpContext.Request;
            var response = httpContext.Response;
            var isHtmlRequest = request.Headers["Accept"]?.Contains("text/html") ?? false;
            response.Headers["Vary"] = "accept";
            if (isHtmlRequest)
            {
                var content = "<!DOCTYPE html> <html lang=\"en\"> <head> <meta charset=\"utf-8\" /> <title>Recuperos</title> <base href=\"/\" /> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" /> <link rel=\"icon\" type=\"image/x-icon\" href=\"favicon.ico\" /> <link href=\"https://fonts.googleapis.com/css?family=Roboto:300,400,500&display=swap\" rel=\"stylesheet\" /> <link href=\"https://fonts.googleapis.com/icon?family=Material+Icons|Material+Icons+Outlined\" rel=\"stylesheet\" /> <script defer src=\"https://use.fontawesome.com/releases/v5.3.1/js/all.js\" ></script> <link rel=\"stylesheet\" href=\"styles.css\"></head> <body class=\"mat-typography\"> <app-root></app-root> <script src=\"runtime-es2015.js\" type=\"module\"></script><script src=\"runtime-es5.js\" nomodule defer></script><script src=\"polyfills-es5.js\" nomodule defer></script><script src=\"polyfills-es2015.js\" type=\"module\"></script><script src=\"main-es2015.js\" type=\"module\"></script><script src=\"main-es5.js\" nomodule defer></script></body> </html>";
                response.Headers["Cache-Control"] = "no-cache";
                filterContext.Result = new ContentResult
                {
                    Content = content,
                    ContentType = "text/html"
                };
            }
            base.OnActionExecuted(filterContext);
        }
    }
}