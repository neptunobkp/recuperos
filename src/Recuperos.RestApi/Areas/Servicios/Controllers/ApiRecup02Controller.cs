using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetAccidente;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetAsegurado;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetConductor;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetConductores;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetConstancia;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetDenunciante;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetFacturas;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetLiquidador;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetPropietario;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetRelato;
using Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetVehiculo;

namespace Recuperos.RestApi.Areas.Servicios.Controllers
{
    [Authorize]
    [RoutePrefix("api/recup02/{numero}")]
    public class ApiRecup02Controller : ApiController
    {
        private readonly IMediator _mediator;
        public ApiRecup02Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("accidente")]
        public async Task<HttpResponseMessage> GetAccidente(int numero)
        {
            return await _mediator.Send(new GetAccidenteQuery() { Numero = numero });
        }

        [HttpGet]
        [Route("asegurado")]
        public async Task<HttpResponseMessage> GetAsegurado(int numero)
        {
            return await _mediator.Send(new GetAseguradoQuery() { Numero = numero });
        }

        [HttpGet]
        [Route("conductor")]
        public async Task<HttpResponseMessage> GetConductor(int numero)
        {
            return await _mediator.Send(new GetConductorQuery() { Numero = numero });
        }

        [HttpGet]
        [Route("constancia")]
        public async Task<HttpResponseMessage> GetConstancia(int numero)
        {
            return await _mediator.Send(new GetConstanciaQuery() { Numero = numero });
        }

        [HttpGet]
        [Route("denunciante")]
        public async Task<HttpResponseMessage> GetDenunciante(int numero)
        {
            return await _mediator.Send(new GetDenuncianteQuery() { Numero = numero });
        }

        [HttpGet]
        [Route("liquidador")]
        public async Task<HttpResponseMessage> GetLiquidador(int numero)
        {
            return await _mediator.Send(new GetLiquidadorQuery() { Numero = numero });
        }

        [HttpGet]
        [Route("relato")]
        public async Task<HttpResponseMessage> GetRelato(int numero)
        {
            return await _mediator.Send(new GetRelatoQuery() { Numero = numero });
        }

        [HttpGet]
        [Route("vehiculo")]
        public async Task<HttpResponseMessage> GetVehiculo(int numero)
        {
            return await _mediator.Send(new GetVehiculoQuery() { Numero = numero });
        }

        [HttpGet]
        [Route("propietario")]
        public async Task<HttpResponseMessage> GetPropietario(int numero)
        {
            return await _mediator.Send(new GetPropietarioQuery() { Numero = numero });
        }

        [HttpGet]
        [Route("conductores")]
        public async Task<HttpResponseMessage> GetConductores(int numero)
        {
            return await _mediator.Send(new GetConductoresQuery() { Numero = numero });
        }

        [HttpGet]
        [Route("facturas")]
        public async Task<FacturasResponseViewModel> GetFacturas(int numero)
        {
            return await _mediator.Send(new GetFacturasQuery() { Numero = numero });
        }
    }
}
