using FluentValidation;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Commands;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Behaviors;

public class TerminalBiometricoEliminarValidator : AbstractValidator<TerminalBiometricoEliminarCommand>
{
    public TerminalBiometricoEliminarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
    }
}
