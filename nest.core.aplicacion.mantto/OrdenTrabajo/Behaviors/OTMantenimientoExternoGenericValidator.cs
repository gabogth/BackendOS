using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajo.Behaviors.Internal;
using nest.core.aplicacion.mantto.OrdenTrabajo.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Behaviors;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Behaviors;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Behaviors
{
    public class OTMantenimientoExternoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IOTMantenimientoExternoGenericCommand
    {
        public OTMantenimientoExternoGenericValidator()
        {
            RuleFor(x => x.Cabecera)
                .NotNull()
                .SetValidator(new OrdenTrabajoCabeceraCrearValidator());

            RuleFor(x => x.Detalles)
                .NotNull()
                .NotEmpty();

            RuleForEach(x => x.Detalles)
                .SetValidator(new OrdenTrabajoMantenimientoExternoDetalleValidator());

            RuleFor(x => x.Personas)
                .NotNull()
                .NotEmpty();

            RuleForEach(x => x.Personas)
                .SetValidator(new OrdenTrabajoPersonalCrearValidator());
        }
    }
}
