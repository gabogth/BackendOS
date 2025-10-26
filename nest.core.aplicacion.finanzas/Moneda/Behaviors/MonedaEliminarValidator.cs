using FluentValidation;
using nest.core.aplicacion.finanzas.Moneda.Commands;

namespace nest.core.aplicacion.finanzas.Moneda.Behaviors
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
