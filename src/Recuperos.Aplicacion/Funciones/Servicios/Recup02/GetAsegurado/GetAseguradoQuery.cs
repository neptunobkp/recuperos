using System.Net.Http;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetAsegurado
{
    public class GetAseguradoQuery : IRequest<HttpResponseMessage>
    {
        public int Numero { get; set; }
    }
}
