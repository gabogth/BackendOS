using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicio.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicio.Behaviors
{
    public class OSMantenimientoExternoModificarValidator : AbstractValidator<OSMantenimientoExternoModificarCommand>
    {
        public OSMantenimientoExternoModificarValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().GreaterThan(0).WithMessage("El Id de la orden de servicio tiene que ser un valor válido.");
            Include(new OSMantenimientoExternoGenericValidator<OSMantenimientoExternoModificarCommand>());
        }
    }
}
