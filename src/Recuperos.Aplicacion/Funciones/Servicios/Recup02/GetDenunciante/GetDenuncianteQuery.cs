using System.Net.Http;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetDenunciante
{
    public class GetDenuncianteQuery : IRequest<HttpResponseMessage>
    {
        public int Numero { get; set; }
    }
}
