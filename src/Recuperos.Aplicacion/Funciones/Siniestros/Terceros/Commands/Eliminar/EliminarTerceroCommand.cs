using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Commands.Eliminar
{
   public class EliminarTerceroCommand : IRequest
    {
        public int Id { get; set; }
    }
}
