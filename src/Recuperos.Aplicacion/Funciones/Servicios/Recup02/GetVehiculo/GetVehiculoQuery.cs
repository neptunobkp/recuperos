using System.Net.Http;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetVehiculo
{
    public class GetVehiculoQuery : IRequest<HttpResponseMessage>
    {
        public int Numero { get; set; }
    }
}
