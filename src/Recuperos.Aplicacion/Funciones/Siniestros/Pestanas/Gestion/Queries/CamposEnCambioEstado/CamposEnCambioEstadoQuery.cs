using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Queries.CamposEnCambioEstado
{
    public class CamposEnCambioEstadoQuery : IRequest<PermisosObtenidosViewModel>
    {
        public int Id { get; set; }
        public int EstadoId { get; set; }
    }
}
