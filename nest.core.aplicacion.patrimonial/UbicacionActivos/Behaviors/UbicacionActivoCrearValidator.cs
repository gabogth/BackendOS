using FluentValidation;
using nest.core.aplicacion.patrimonial.UbicacionActivos.Commands;

namespace nest.core.aplicacion.patrimonial.UbicacionActivos.Behaviors
{
    public class UbicacionActivoCrearValidator : AbstractValidator<UbicacionActivoCrearCommand>
    {
        public UbicacionActivoCrearValidator()
        {
            Include(new UbicacionActivoGenericValidator<UbicacionActivoCrearCommand>());
        }
    }
}
