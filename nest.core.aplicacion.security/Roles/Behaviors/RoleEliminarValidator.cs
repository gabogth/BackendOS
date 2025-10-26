using FluentValidation;
using nest.core.aplicacion.security.Roles.Commands;

namespace nest.core.aplicacion.security.Roles.Behaviors;

public class RoleEliminarValidator : AbstractValidator<RoleEliminarCommand>
{
    public RoleEliminarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
    }
}
