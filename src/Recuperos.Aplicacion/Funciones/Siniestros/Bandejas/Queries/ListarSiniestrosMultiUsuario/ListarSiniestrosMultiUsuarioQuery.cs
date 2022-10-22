using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario
{
    public class ListarSiniestrosMultiUsuarioQuery : IRequest<SiniestroMultiUsuarioResponseViewModel>, IListarSiniestroQuery
    {
        public int EtapaId { get; set; }
        public int Pagina { get; set; }
        public int ItemsPorPagina { get; set; }
        public string Orden { get; set; }
        public string Direccion { get; set; }
        public FiltroSiniestros Filtros { get; set; }
    }
}
