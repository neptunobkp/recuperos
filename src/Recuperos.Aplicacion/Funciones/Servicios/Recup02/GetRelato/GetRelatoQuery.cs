using System.Net.Http;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetRelato
{
    public class GetRelatoQuery : IRequest<HttpResponseMessage>
    {
        public int Numero { get; set; }
    }
}
