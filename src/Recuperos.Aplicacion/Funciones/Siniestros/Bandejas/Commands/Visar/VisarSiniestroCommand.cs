using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Commands.Visar
{
    public class VisarSiniestroCommand : IRequest
    {
        public int Id { get; set; }
        public bool Aceptado { get; set; }
        public RechazoVisadoCommandViewModel Motivo { get; set; }

    }
}
