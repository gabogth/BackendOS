using FluentValidation;
using nest.core.aplicacion.security.RoleClaims.Commands;

namespace nest.core.aplicacion.security.RoleClaims.Behaviors;

public class RoleClaimsEliminarValidator : AbstractValidator<RoleClaimsEliminarCommand>
{
    public RoleClaimsEliminarValidator()
    {
        RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage("El identificador del rol es obligatorio.");
    }
}
