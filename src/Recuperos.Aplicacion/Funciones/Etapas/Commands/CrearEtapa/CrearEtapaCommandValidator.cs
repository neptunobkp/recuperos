using FluentValidation;

namespace Recuperos.Aplicacion.Funciones.Etapas.Commands.CrearEtapa
{
    public class CrearEtapaCommandValidator : AbstractValidator<CrearEtapaCommand>
    {
        public CrearEtapaCommandValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("Nombre requerido");
        }
    }
}
