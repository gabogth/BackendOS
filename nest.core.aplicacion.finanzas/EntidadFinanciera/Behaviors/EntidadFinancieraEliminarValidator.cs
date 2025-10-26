using FluentValidation;
using nest.core.aplicacion.finanzas.EntidadFinanciera.Commands;

namespace nest.core.aplicacion.finanzas.EntidadFinanciera.Behaviors
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
