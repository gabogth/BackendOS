using FluentValidation;
using nest.core.aplicacion.finanzas.Terceros.Commands;

namespace nest.core.aplicacion.finanzas.Terceros.Behaviors
{
    public class TerceroCrearValidator : AbstractValidator<TerceroCrearCommand>
    {
        public TerceroCrearValidator()
        {
            Include(new TerceroGenericValidator<TerceroCrearCommand>());
        }
    }
}
