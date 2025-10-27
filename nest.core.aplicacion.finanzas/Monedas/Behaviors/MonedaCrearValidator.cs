using FluentValidation;
using nest.core.aplicacion.finanzas.Monedas.Commands;

namespace nest.core.aplicacion.finanzas.Monedas.Behaviors
{
    public class MonedaCrearValidator : AbstractValidator<MonedaCrearCommand>
    {
        public MonedaCrearValidator()
        {
            Include(new MonedaGenericValidator<MonedaCrearCommand>());
        }
    }
}
