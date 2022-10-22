using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Archivos.Commands.Agregar;
using Recuperos.Aplicacion.Funciones.Siniestros.Archivos.Commands.Eliminar;
using Recuperos.Aplicacion.Funciones.Siniestros.Archivos.Queries.Listar;
using Recuperos.Aplicacion.Funciones.Siniestros.Archivos.Queries.Obtener;
using Recuperos.RestApi.Infraestructura;

namespace Recuperos.RestApi.Areas.Siniestro.Controllers
{
    [Authorize]
    [RoutePrefix("api/siniestros/{id}/Adjuntos")]
    public class AdjuntosController : ApiController
    {
        private readonly IMediator _mediator;

        public AdjuntosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IEnumerable<ArchivoAdjuntoViewModel>> Get(int id)
        {
            return await _mediator.Send(new ListarArchivosQuery { SiniestroId = id });
        }

        [HttpGet]
        [Route("descargar")]
        public async Task<HttpResponseMessage> Descargar(int id, int archivoId)
        {
            var archivo = await _mediator.Send(new ObtenerArchivoQuery { Id = archivoId });
            var result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(archivo.Buffer) };
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = archivo.Nombre };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(archivo.ContentType);
            return result;
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<Unit> Eliminar(int id, int archivoId)
        {
            return await _mediator.Send(new EliminarArchivoCommand { Id = archivoId });
        }

        [HttpPost]
        [Route("crear")]
        public async Task<Unit> PostCrear(int id)
        {

            var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(
                    new InMemoryMultipartFormDataStreamProvider());

            return await _mediator.Send(new AgregarArchivoCommand
            {
                SiniestroId = id,
                Data = Convert.ToBase64String(await provider.Files[0].ReadAsByteArrayAsync()),
                Nombre = Path.GetFileName(provider.Files[0].Headers.ContentDisposition.FileName.Trim('\"')),
                Extension = provider.Files[0].Headers.ContentType.MediaType
            });
        }
    }
}
