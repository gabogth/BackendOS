using FluentValidation;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Commands;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Behaviors;

public class TerminalBiometricoCrearValidator : AbstractValidator<TerminalBiometricoCrearCommand>
{
    public TerminalBiometricoCrearValidator()
    {
        Include(new TerminalBiometricoGenericValidator<TerminalBiometricoCrearCommand>());
    }
}
