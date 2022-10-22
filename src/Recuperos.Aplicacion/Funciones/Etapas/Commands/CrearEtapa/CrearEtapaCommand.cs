using MediatR;

namespace Recuperos.Aplicacion.Funciones.Etapas.Commands.CrearEtapa
{
    public class CrearEtapaCommand : IRequest<int>
    {
        public string Nombre { get; set; }


    }
}
