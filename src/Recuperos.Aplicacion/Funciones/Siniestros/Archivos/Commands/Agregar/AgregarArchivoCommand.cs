using MediatR;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Archivos.Commands.Agregar
{
    public class AgregarArchivoCommand : IRequest
    {
        public string Data { get; set; }
        public int SiniestroId { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
    }
}