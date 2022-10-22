using MediatR;

namespace Recuperos.Aplicacion.Funciones.Estados.Commands.CrearEstado
{
    public class CrearEstadoCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public string EtapaId { get; set; }

    }
}
