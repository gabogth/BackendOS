using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajo.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Behaviors.Internal
{
    internal sealed class OrdenTrabajoMantenimientoExternoDetalleActivoValidator : AbstractValidator<OrdenTrabajoMantenimientoExternoDetalleActivoRegistro>
    {
        public OrdenTrabajoMantenimientoExternoDetalleActivoValidator()
        {
            RuleFor(x => x.ActivoId)
                .GreaterThan(0);
        }
    }
}
