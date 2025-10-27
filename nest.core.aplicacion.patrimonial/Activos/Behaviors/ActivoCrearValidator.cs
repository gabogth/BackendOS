using FluentValidation;
using nest.core.aplicacion.patrimonial.Activos.Commands;

namespace nest.core.aplicacion.patrimonial.Activos.Behaviors
{
    public class ActivoCrearValidator : AbstractValidator<ActivoCrearCommand>
    {
        public ActivoCrearValidator()
        {
            Include(new ActivoGenericValidator<ActivoCrearCommand>());
        }
    }
}
