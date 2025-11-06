using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajo.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Behaviors
{
    public class OTMantenimientoExternoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IOTMantenimientoExternoGenericCommand
    {
        public OTMantenimientoExternoGenericValidator()
        {
            //RuleFor(x => x.Cabecera)
            //    .NotNull()
            //    .SetValidator(new OrdenTrabajoCabeceraCrearValidator());

            //RuleFor(x => x.Detalles)
            //    .NotNull()
            //    .NotEmpty();

            //RuleForEach(x => x.Detalles)
            //    .SetValidator(new OrdenTrabajoMantenimientoExternoDetalleValidator());

            //RuleFor(x => x.Personas)
            //    .NotNull()
            //    .NotEmpty();

            //RuleForEach(x => x.Personas)
            //    .SetValidator(new OrdenTrabajoPersonalCrearValidator());
        }
    }
}
