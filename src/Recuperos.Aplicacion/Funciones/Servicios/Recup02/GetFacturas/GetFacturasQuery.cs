using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetFacturas
{
    public class GetFacturasQuery : IRequest<FacturasResponseViewModel>
    {
        public int Numero { get; set; }
    }
}
