using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.BuscarVehiculo
{
    public class BuscarVehiculoQuery : IRequest<ResultadoPorPatenteViewModel>
    {
        public string Patente { get; set; }
    }
}
