using System.Net.Http;
using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetLiquidador
{
    public class GetLiquidadorQuery : IRequest<HttpResponseMessage>
    {
        public int Numero { get; set; }
    }
}
