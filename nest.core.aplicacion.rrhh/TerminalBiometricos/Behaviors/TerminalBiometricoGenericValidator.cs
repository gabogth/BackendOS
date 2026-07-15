using FluentValidation;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Commands;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Behaviors
{
    public class TerminalBiometricoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : ITerminalBiometricoGenericCommand
    {
        public TerminalBiometricoGenericValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("La empresa es obligatoria.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");

            RuleFor(x => x.SN)
                .NotEmpty().WithMessage("El número de serie es obligatorio.")
                .MaximumLength(200).WithMessage("El número de serie no puede exceder 200 caracteres.");
        }
    }
}
