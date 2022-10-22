using MediatR;

namespace Recuperos.Aplicacion.Funciones.Etapas.Commands.EditarEtapa
{
    public class EditarEtapaCommand : IRequest
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
    
    }
}
