using FluentValidation;
using nest.core.aplicacion.finanzas.Financiero.Commands;

namespace nest.core.aplicacion.finanzas.Financiero.Behaviors
{
    public class FinancieroCrearValidator : AbstractValidator<FinancieroCrearCommand>
    {
        public FinancieroCrearValidator()
        {
            Include(new FinancieroGenericValidator<FinancieroCrearCommand>());
        }
    }
}
