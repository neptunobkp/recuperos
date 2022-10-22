using System;
using System.IO;
using System.Web.Mvc;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result {
    public class FileDownloadResult : ActionResult {
        public string FileName { get; }
        public string ContentType { get; }
        public Func<Stream> OpenRead { get; }

        public FileDownloadResult(string fileName, string contentType, Func<Stream> openRead) {
            FileName = fileName;
            ContentType = contentType;
            OpenRead = openRead;
        }

        public override void ExecuteResult(ControllerContext context) {
            var response = context.HttpContext.Response;

            response.ContentType = ContentType;
            response.Headers.Add("content-disposition", $"inline; filename={FileName}");
            response.StatusCode = 200;

            using (var fileStream = OpenRead()) {
                fileStream.CopyTo(response.OutputStream);
                response.OutputStream.Flush();
            }

            response.End();
        }
    }
}
