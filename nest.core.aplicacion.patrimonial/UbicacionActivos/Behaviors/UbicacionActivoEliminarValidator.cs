using FluentValidation;
using nest.core.aplicacion.patrimonial.UbicacionActivos.Commands;

namespace nest.core.aplicacion.patrimonial.UbicacionActivos.Behaviors
{
    public class UbicacionActivoEliminarValidator : AbstractValidator<UbicacionActivoEliminarCommand>
    {
        public UbicacionActivoEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador del registro es obligatorio.");
        }
    }
}
