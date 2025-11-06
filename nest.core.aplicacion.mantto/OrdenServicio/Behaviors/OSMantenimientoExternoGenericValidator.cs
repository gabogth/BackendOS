using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicio.Commands;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Behaviors;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Behaviors;

namespace nest.core.aplicacion.mantto.OrdenServicio.Behaviors
{
    public class OSMantenimientoExternoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IOSMantenimientoExternoGenericCommand
    {
        public OSMantenimientoExternoGenericValidator()
        {
            RuleFor(x => x.Cabecera)
                .NotNull()
                .SetValidator(new OrdenServicioCabeceraCrearValidator());

            RuleFor(x => x.Externo)
                .NotNull()
                .SetValidator(new OrdenServicioMantenimientoExternoCrearValidator());
        }
    }
}
