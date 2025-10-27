using FluentValidation;
using nest.core.aplicacion.patrimonial.UbicacionTecnicas.Commands;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicas.Behaviors
{
    public class UbicacionTecnicaCrearValidator : AbstractValidator<UbicacionTecnicaCrearCommand>
    {
        public UbicacionTecnicaCrearValidator()
        {
            Include(new UbicacionTecnicaGenericValidator<UbicacionTecnicaCrearCommand>());
        }
    }
}
