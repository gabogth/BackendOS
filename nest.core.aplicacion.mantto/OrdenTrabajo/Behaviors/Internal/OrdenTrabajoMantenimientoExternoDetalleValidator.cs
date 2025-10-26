using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajo.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Behaviors.Internal
{
    internal sealed class OrdenTrabajoMantenimientoExternoDetalleValidator : AbstractValidator<OrdenTrabajoMantenimientoExternoDetalleRegistro>
    {
        public OrdenTrabajoMantenimientoExternoDetalleValidator()
        {
            RuleFor(x => x.Detalle)
                .NotNull()
                .SetValidator(new OrdenTrabajoDetalleUpsertValidator());

            RuleFor(x => x.Activo)
                .NotNull()
                .SetValidator(new OrdenTrabajoMantenimientoExternoDetalleActivoValidator());
        }
    }
}
