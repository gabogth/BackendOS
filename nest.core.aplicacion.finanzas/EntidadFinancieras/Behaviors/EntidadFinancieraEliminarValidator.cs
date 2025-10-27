using FluentValidation;
using nest.core.aplicacion.finanzas.EntidadFinancieras.Commands;

namespace nest.core.aplicacion.finanzas.EntidadFinancieras.Behaviors
{
    public class EntidadFinancieraEliminarValidator : AbstractValidator<EntidadFinancieraEliminarCommand>
    {
        public EntidadFinancieraEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
        }
    }
}
