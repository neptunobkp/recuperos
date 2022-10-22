using MediatR;

namespace Recuperos.Aplicacion.Funciones.Servicios.Equifax.BuscarVehiculoEquifax
{
    public class BuscarVehiculoEquifaxQuery : IRequest<ResultadoPorPatenteEquifaxViewModel>
    {
        public string Patente { get; set; }
        public int SiniestroId { get; set; }
    }
}
