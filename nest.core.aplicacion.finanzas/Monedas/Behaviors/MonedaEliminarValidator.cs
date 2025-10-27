using FluentValidation;
using nest.core.aplicacion.finanzas.Monedas.Commands;

namespace nest.core.aplicacion.finanzas.Monedas.Behaviors
{
    public class MonedaEliminarValidator : AbstractValidator<MonedaEliminarCommand>
    {
        public MonedaEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
        }
    }
}
