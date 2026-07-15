using FluentValidation;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Commands;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Behaviors;

public class TerminalBiometricoModificarValidator : AbstractValidator<TerminalBiometricoModificarCommand>
{
    public TerminalBiometricoModificarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");

        Include(new TerminalBiometricoGenericValidator<TerminalBiometricoModificarCommand>());
    }
}
