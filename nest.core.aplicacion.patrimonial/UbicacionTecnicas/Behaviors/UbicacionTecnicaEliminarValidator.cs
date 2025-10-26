using FluentValidation;
using nest.core.aplicacion.patrimonial.UbicacionTecnicas.Commands;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicas.Behaviors
{
    public class UbicacionTecnicaEliminarValidator : AbstractValidator<UbicacionTecnicaEliminarCommand>
    {
        public UbicacionTecnicaEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador de la ubicación técnica es obligatorio.");
        }
    }
}
