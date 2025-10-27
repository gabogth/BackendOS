using FluentValidation;
using nest.core.aplicacion.security.Roles.Commands;

namespace nest.core.aplicacion.security.Roles.Behaviors;

public class RoleCrearValidator : AbstractValidator<RoleCrearCommand>
{
    public RoleCrearValidator()
    {
        Include(new RoleGenericValidator<RoleCrearCommand>());
    }
}
