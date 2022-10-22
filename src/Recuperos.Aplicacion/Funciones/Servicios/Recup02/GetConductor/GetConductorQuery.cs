using System.Net.Http;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetConductor
{
    public class GetConductorQuery : IRequest<HttpResponseMessage>
    {
        public int Numero { get; set; }
    }
}
