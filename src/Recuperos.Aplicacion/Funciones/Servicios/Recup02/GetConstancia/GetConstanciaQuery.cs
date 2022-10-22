using System.Net.Http;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetConstancia
{
    public class GetConstanciaQuery : IRequest<HttpResponseMessage>
    {
        public int Numero { get; set; }
    }
}
