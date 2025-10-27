using FluentValidation;
using nest.core.aplicacion.finanzas.Monedas.Commands;

namespace nest.core.aplicacion.finanzas.Monedas.Behaviors
{
    public class MonedaModificarValidator : AbstractValidator<MonedaModificarCommand>
    {
        public MonedaModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            Include(new MonedaGenericValidator<MonedaModificarCommand>());
        }
    }
}
