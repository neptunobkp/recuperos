using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Commands.Asignar
{
    public class AsignarCommand : IRequest
    {
        public int SiniestroId { get; set; }
        public int EjecutivoId { get; set; }
        public int OwnerId { get; set; }
    }
}
