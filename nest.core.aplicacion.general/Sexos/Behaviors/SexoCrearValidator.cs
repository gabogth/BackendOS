using FluentValidation;
using nest.core.aplicacion.general.Sexos.Commands;

namespace nest.core.aplicacion.general.Sexos.Behaviors
{
    public class SexoCrearValidator : AbstractValidator<SexoCrearCommand>
    {
        public SexoCrearValidator()
        {
            Include(new SexoGenericValidator<SexoCrearCommand>());
        }
    }
}
