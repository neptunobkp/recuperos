using MediatR;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Commands.CambiarEstadoCommand.Pipelines.PreCambioEstado
{
    public class PreCambioEstadoSiniestro : INotification
    {
        public Estado NuevoEstado { get; set; }
        public Siniestro Siniestro { get; set; }
    }
}
