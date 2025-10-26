using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajo.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Behaviors.Internal
{
    internal sealed class OrdenTrabajoDetalleUpsertValidator : AbstractValidator<OrdenTrabajoDetalleUpsertCommand>
    {
        public OrdenTrabajoDetalleUpsertValidator()
        {
            RuleFor(x => x.UbicacionTecnicaId)
                .GreaterThan(0);

            RuleFor(x => x.LaborId)
                .GreaterThan(0);

            RuleFor(x => x.HorasProyectadas)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.HorasEjecutadas)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Estado)
                .IsInEnum();
        }
    }
}
