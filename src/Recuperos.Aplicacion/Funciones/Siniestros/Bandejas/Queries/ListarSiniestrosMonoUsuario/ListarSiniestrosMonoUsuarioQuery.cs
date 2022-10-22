using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMonoUsuario
{
    public class ListarSiniestrosMonoUsuarioQuery : IRequest<SiniestroMonoUsuarioResponseViewModel>, IListarSiniestroQuery
    {
        public int EtapaId { get; set; }
        public int Pagina { get; set; }
        public int ItemsPorPagina { get; set; }
        public string Orden { get; set; }
        public string Numero { get; set; }
        public string Compania { get; set; }

        public int EjecutivoId { get; set; }

        public FiltroSiniestros Filtros { get; set; }
    }
}
