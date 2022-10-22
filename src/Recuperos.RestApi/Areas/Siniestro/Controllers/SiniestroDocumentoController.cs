using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Documentos.Queries;

namespace Recuperos.RestApi.Areas.Siniestro.Controllers
{
    [Authorize]
    public class SiniestroDocumentoController : ApiController
    {
        private readonly IMediator _mediator;

        public SiniestroDocumentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<SiniestroDocumentoViewModel> Get(int id)
        {
            var result  = await _mediator.Send(new DocumentosSiniestroQuery {Id = id});
            if (result == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return result;
        }
    }
}
