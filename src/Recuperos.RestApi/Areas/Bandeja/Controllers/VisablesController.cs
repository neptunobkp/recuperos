using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosVisables;

namespace Recuperos.RestApi.Areas.Bandeja.Controllers
{
    [Authorize]
    [RoutePrefix("api/Visables")]
    public class VisablesController : ApiController
    {
        private readonly IMediator _mediator;
        public VisablesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Filtrar")]
        public async Task<SiniestroVisablesResponseViewModel> Post([FromBody] ListarSiniestrosVisablesQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost]
        [Route("Exportar")]
        public async Task<HttpResponseMessage> Post([FromBody] ExportarSiniestrosVisablesQuery query)
        {
            var reportStream = await _mediator.Send(query);
            var result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(reportStream) };
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Siniestros.xlsx" };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }

       
    }
}
