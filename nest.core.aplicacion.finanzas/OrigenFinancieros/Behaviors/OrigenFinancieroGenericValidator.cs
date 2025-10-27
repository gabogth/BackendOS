using FluentValidation;
using nest.core.aplicacion.finanzas.OrigenFinancieros.Commands;

namespace nest.core.aplicacion.finanzas.OrigenFinancieros.Behaviors
{
    public class OrigenFinancieroGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IOrigenFinancieroGenericCommand
    {
        public OrigenFinancieroGenericValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(150).WithMessage("El nombre debe tener como máximo 150 caracteres.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es requerido.")
                .MaximumLength(50).WithMessage("El nombre corto debe tener como máximo 50 caracteres.");

            RuleFor(x => x.Naturaleza)
                .NotEmpty().WithMessage("La naturaleza es requerida.")
                .MaximumLength(50).WithMessage("La naturaleza debe tener como máximo 50 caracteres.");
        }
    }
}
