using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Commands.Editar
{
    public class EditarTerceroCommand : TerceroCommandBase, IRequest
    {
        public int Id { get; set; }
    }
}
