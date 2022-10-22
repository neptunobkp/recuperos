using FluentValidation;

namespace Recuperos.Aplicacion.Funciones.Estados.Commands.CrearEstado
{
    public class CrearEstadoCommandValidator : AbstractValidator<CrearEstadoCommand>
    {
        public CrearEstadoCommandValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("Nombre requerido");
        }
    }
}
