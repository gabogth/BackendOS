using FluentValidation;
using nest.core.aplicacion.security.RoleClaims.Commands;

namespace nest.core.aplicacion.security.RoleClaims.Behaviors;

public class RoleClaimsMergeValidator : AbstractValidator<RoleClaimsMergeCommand>
{
    public RoleClaimsMergeValidator()
    {
        RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage("El identificador del rol es obligatorio.");
        RuleFor(x => x.Claims)
            .NotNull().WithMessage("Debe proporcionar claims.");
        RuleForEach(x => x.Claims)
            .ChildRules(claim =>
            {
                claim.RuleFor(c => c.Type)
                    .NotEmpty().WithMessage("El tipo de claim es obligatorio.");
                claim.RuleFor(c => c.Value)
                    .NotEmpty().WithMessage("El valor del claim es obligatorio.");
            });
    }
}
