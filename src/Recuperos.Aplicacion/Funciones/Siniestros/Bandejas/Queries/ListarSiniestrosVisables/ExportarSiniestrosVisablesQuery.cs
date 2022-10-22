using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosVisables
{
    public class ExportarSiniestrosVisablesQuery : IRequest<byte[]> , IListarSiniestroVisablesQuery
    {
        public int EtapaId { get; set; }
        public int Pagina { get; set; }
        public int ItemsPorPagina { get; set; }
        public string Orden { get; set; }
        public FiltroSiniestrosVisables Filtros { get; set; }
    }
}
