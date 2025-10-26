using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Behaviors
{
    public class OrdenServicioMantenimientoExternoEliminarValidator : AbstractValidator<OrdenServicioMantenimientoExternoEliminarCommand>
    {
        public OrdenServicioMantenimientoExternoEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a 0.");
        }
    }
}
