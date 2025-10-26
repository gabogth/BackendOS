using FluentValidation;
using nest.core.aplicacion.security.Roles.Commands;

namespace nest.core.aplicacion.security.Roles.Behaviors;

public class RoleModificarValidator : AbstractValidator<RoleModificarCommand>
{
    public RoleModificarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(256).WithMessage("El nombre no puede exceder 256 caracteres.");
    }
}
