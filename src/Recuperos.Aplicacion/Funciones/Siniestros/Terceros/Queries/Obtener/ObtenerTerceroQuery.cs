using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.Obtener
{
   public class ObtenerTerceroQuery : IRequest<TerceroViewModel>
    {
        public int Id { get; set; }
    }
}
