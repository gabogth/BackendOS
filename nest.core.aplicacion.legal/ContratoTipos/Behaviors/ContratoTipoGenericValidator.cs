using FluentValidation;
using nest.core.aplicacion.legal.ContratoTipos.Commands;

namespace nest.core.aplicacion.legal.ContratoTipos.Behaviors
{
    public class ContratoTipoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IContratoTipoGenericCommand
    {
        public ContratoTipoGenericValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre debe tener como máximo 150 caracteres.");

            RuleFor(x => x.Detalle)
                .NotEmpty().WithMessage("El detalle es requerido.")
                .MaximumLength(500).WithMessage("El detalle debe tener como máximo 500 caracteres.");
        }
    }
}
