using FluentValidation;
using nest.core.aplicacion.security.RoleUsuarios.Commands;

namespace nest.core.aplicacion.security.RoleUsuarios.Behaviors;

public class RoleUsuarioMergeValidator : AbstractValidator<RoleUsuarioMergeCommand>
{
    public RoleUsuarioMergeValidator()
    {
        RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage("El Id del rol es obligatorio.");
        RuleFor(x => x.UsersId)
            .NotNull().WithMessage("Debe proporcionar usuarios.")
            .Must(x => x.Count > 0).WithMessage("Debe proporcionar al menos un usuario.");
    }
}
