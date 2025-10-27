using FluentValidation;
using nest.core.aplicacion.mantto.Labores.Commands;

namespace nest.core.aplicacion.mantto.Labores.Behaviors
{
    public class LaborCrearValidator : AbstractValidator<LaborCrearCommand>
    {
        public LaborCrearValidator()
        {
            Include(new LaborGenericValidator<LaborCrearCommand>());
        }
    }
}
