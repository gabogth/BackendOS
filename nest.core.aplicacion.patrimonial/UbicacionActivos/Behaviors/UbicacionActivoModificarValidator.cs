using FluentValidation;
using nest.core.aplicacion.patrimonial.UbicacionActivos.Commands;

namespace nest.core.aplicacion.patrimonial.UbicacionActivos.Behaviors
{
    public class UbicacionActivoModificarValidator : AbstractValidator<UbicacionActivoModificarCommand>
    {
        public UbicacionActivoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador del registro es obligatorio.");
            Include(new UbicacionActivoGenericValidator<UbicacionActivoModificarCommand>());
        }
    }
}
