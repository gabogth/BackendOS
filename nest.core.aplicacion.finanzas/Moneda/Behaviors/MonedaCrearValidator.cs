using FluentValidation;
using nest.core.aplicacion.finanzas.Moneda.Commands;

namespace nest.core.aplicacion.finanzas.Moneda.Behaviors
{
    public class MonedaCrearValidator : AbstractValidator<MonedaCrearCommand>
    {
        public MonedaCrearValidator()
        {
            Include(new MonedaGenericValidator<MonedaCrearCommand>());
        }
    }
}
