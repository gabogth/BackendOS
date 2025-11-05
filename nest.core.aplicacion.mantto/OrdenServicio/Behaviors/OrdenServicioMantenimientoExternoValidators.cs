using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicio.Commands;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Behaviors;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Behaviors;

namespace nest.core.aplicacion.mantto.OrdenServicio.Behaviors
{
    public class OrdenServicioMantenimientoExternoCommandBaseValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : OrdenServicioMantenimientoExternoCommandBase
    {
        public OrdenServicioMantenimientoExternoCommandBaseValidator()
        {
            RuleFor(x => x.Cabecera)
                .NotNull()
                .SetValidator(new OrdenServicioCabeceraCrearValidator());

            RuleFor(x => x.Externo)
                .NotNull()
                .SetValidator(new OrdenServicioMantenimientoExternoCrearValidator());
        }
    }

    public class OrdenServicioMantenimientoExternoRegistrarValidator
        : OrdenServicioMantenimientoExternoCommandBaseValidator<OrdenServicioMantenimientoExternoRegistrarCommand>
    {
    }

    public class OrdenServicioMantenimientoExternoActualizarValidator
        : OrdenServicioMantenimientoExternoCommandBaseValidator<OrdenServicioMantenimientoExternoActualizarCommand>
    {
        public OrdenServicioMantenimientoExternoActualizarValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public class OrdenServicioMantenimientoExternoEliminarValidator
        : AbstractValidator<OrdenServicioMantenimientoExternoEliminarCommand>
    {
        public OrdenServicioMantenimientoExternoEliminarValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
