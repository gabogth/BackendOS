using FluentValidation;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Commands;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Behaviors
{
    public class EstructuraOrganizacionalEliminarValidator : AbstractValidator<EstructuraOrganizacionalEliminarCommand>
    {
        public EstructuraOrganizacionalEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a cero.");
        }
    }
}
