using FluentValidation;
using nest.core.aplicacion.security.Login.Commands;

namespace nest.core.aplicacion.security.Login.Behaviors;

public class CambiarEmpresaCommandValidator : AbstractValidator<CambiarEmpresaCommand>
{
    public CambiarEmpresaCommandValidator()
    {
        Include(new LoginGenericValidator<CambiarEmpresaCommand>());

        RuleFor(command => command.EmpresaId)
            .GreaterThan(0).WithMessage("La empresa seleccionada no es válida.");
    }
}
