using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.Listar
{
    public class ListarTercerosQuery : IRequest<PaginaListableTerceroViewModel>
    {
        public int SiniestroId { get; set; }
        public int Pagina { get; set; }
        public int ItemsPorPagina { get; set; }
    }
}
