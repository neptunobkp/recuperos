using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Commands.Agregar
{
    public class AgregarTerceroCommand : TerceroCommandBase, IRequest<int>
    {
        public int SiniestroId { get; set; }
    }
}
