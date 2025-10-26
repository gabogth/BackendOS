using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Behaviors
{
    public class OrdenTrabajoDetalleEliminarValidator : AbstractValidator<OrdenTrabajoDetalleEliminarCommand>
    {
        public OrdenTrabajoDetalleEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador del detalle es obligatorio.");
        }
    }
}
