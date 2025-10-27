using FluentValidation;
using nest.core.aplicacion.patrimonial.Activos.Commands;

namespace nest.core.aplicacion.patrimonial.Activos.Behaviors
{
    public class ActivoModificarValidator : AbstractValidator<ActivoModificarCommand>
    {
        public ActivoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador del activo es obligatorio.");
            Include(new ActivoGenericValidator<ActivoModificarCommand>());
        }
    }
}
