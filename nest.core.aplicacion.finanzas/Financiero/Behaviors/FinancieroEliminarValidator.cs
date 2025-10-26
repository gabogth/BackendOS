using FluentValidation;
using nest.core.aplicacion.finanzas.Financiero.Commands;

namespace nest.core.aplicacion.finanzas.Financiero.Behaviors
{
    public class FinancieroEliminarValidator : AbstractValidator<FinancieroEliminarCommand>
    {
        public FinancieroEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
        }
    }
}
