using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Behaviors
{
    public class OrdenTrabajoDetalleActivoEliminarValidator : AbstractValidator<OrdenTrabajoDetalleActivoEliminarCommand>
    {
        public OrdenTrabajoDetalleActivoEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador del registro es obligatorio.");
        }
    }
}
