using System.Net.Http;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetConductores
{
    public class GetConductoresQuery : IRequest<HttpResponseMessage>
    {
        public int Numero { get; set; }
    }
}
