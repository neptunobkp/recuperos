using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario
{
    public class ExportarSiniestrosMultiUsuarioQuery : IRequest<byte[]> , IListarSiniestroQuery
    {
        public int EtapaId { get; set; }
        public int Pagina { get; set; }
        public int ItemsPorPagina { get; set; }
        public string Orden { get; set; }
        public FiltroSiniestros Filtros { get; set; }
    }
}
