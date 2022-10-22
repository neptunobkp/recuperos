using FluentValidation;

namespace Recuperos.Aplicacion.Funciones.Estados.Queries.ListarEstados
{
    public class ListarEstadosQueryValidator : AbstractValidator<ListarEstadosQuery>
    {
        public ListarEstadosQueryValidator()
        {
            RuleFor(x => x.EtapaId).GreaterThan(-3).WithMessage("debe ser especificada");
        }
    }
}
