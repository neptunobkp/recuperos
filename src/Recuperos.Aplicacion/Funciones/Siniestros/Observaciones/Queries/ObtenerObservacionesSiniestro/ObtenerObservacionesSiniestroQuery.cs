using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Observaciones.Queries.ObtenerObservacionesSiniestro
{
   public  class ObtenerObservacionesSiniestroQuery : IRequest<ObservacionesResponseViewModel>
    {
        public int SiniestroId { get; set; }
        public int Pagina { get; set; }
        public int ItemsPorPagina { get; set; }
        public string Orden { get; set; }
    }
}
