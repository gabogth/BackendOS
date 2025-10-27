using FluentValidation;
using nest.core.aplicacion.general.Adjuntos.Commands;

namespace nest.core.aplicacion.general.Adjuntos.Behaviors
{
    public class AdjuntoCrearValidator : AbstractValidator<AdjuntoCrearCommand>
    {
        public AdjuntoCrearValidator()
        {
            Include(new AdjuntoGenericValidator<AdjuntoCrearCommand>());
        }
    }
}
