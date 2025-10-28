using FluentValidation;
using nest.core.aplicacion.security.Roles.Commands;

namespace nest.core.aplicacion.security.Roles.Behaviors;

public class RoleCrearValidator : AbstractValidator<RoleCrearCommand>
{
    public RoleCrearValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(256).WithMessage("El nombre no puede exceder 256 caracteres.");
    }
}
