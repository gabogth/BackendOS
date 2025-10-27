using FluentValidation;
using nest.core.aplicacion.finanzas.FinancieroCabeceras.Commands;

namespace nest.core.aplicacion.finanzas.FinancieroCabeceras.Behaviors
{
    public class FinancieroCabeceraEliminarValidator : AbstractValidator<FinancieroCabeceraEliminarCommand>
    {
        public FinancieroCabeceraEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
        }
    }
}
