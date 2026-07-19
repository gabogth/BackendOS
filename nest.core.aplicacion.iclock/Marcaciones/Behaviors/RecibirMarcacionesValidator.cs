using FluentValidation;
using nest.core.aplicacion.iclock.Marcaciones.Commands;

namespace nest.core.aplicacion.iclock.Marcaciones.Behaviors
{
    public class RecibirMarcacionesValidator : AbstractValidator<RecibirMarcacionesCommand>
    {
        public RecibirMarcacionesValidator()
        {
            RuleFor(x => x.DocumentoTipo)
                .GreaterThan(0).WithMessage("El tipo de documento es obligatorio.");

            RuleFor(x => x.DocumentoNumero)
                .NotNull().NotEmpty().WithMessage("El número de documento es obligatorio.");
        }
    }
}
