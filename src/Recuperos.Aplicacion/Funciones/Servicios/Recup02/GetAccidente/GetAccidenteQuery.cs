using System.Net.Http;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetAccidente
{
    public class GetAccidenteQuery : IRequest<HttpResponseMessage>
    {
        public int Numero { get; set; }
    }
}
