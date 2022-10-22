using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Archivos.Queries.Obtener
{
    public class ObtenerArchivoQuery : IRequest<ArchivoObtenidoViewModel>
    {
        public int Id { get; set; }
    }
}
