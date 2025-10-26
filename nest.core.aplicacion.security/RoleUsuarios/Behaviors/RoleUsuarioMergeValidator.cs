using FluentValidation;
using nest.core.aplicacion.security.RoleUsuarios.Commands;

namespace nest.core.aplicacion.security.RoleUsuarios.Behaviors;

public class RoleUsuarioMergeValidator : AbstractValidator<RoleUsuarioMergeCommand>
{
    public RoleUsuarioMergeValidator()
    {
        RuleFor(x => x.RoleName)
            .NotEmpty().WithMessage("El nombre del rol es obligatorio.");
        RuleFor(x => x.UsersId)
            .NotNull().WithMessage("Debe proporcionar usuarios.")
            .Must(x => x.Count > 0).WithMessage("Debe proporcionar al menos un usuario.");
    }
}
