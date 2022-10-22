using System.Net.Http;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetPropietario
{
    public class GetPropietarioQuery : IRequest<HttpResponseMessage>
    {
        public int Numero { get; set; }
    }
}
