using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Behaviors
{
    public class OrdenServicioMantenimientoExternoModificarValidator : AbstractValidator<OrdenServicioMantenimientoExternoModificarCommand>
    {
        public OrdenServicioMantenimientoExternoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a 0.");

            Include(new OrdenServicioMantenimientoExternoCrearValidator());
        }
    }
}
