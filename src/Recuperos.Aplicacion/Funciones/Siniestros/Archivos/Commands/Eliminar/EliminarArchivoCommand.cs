using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Archivos.Commands.Eliminar
{
    public class EliminarArchivoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
