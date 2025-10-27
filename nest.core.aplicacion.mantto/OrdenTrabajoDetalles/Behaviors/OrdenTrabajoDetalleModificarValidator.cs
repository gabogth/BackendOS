using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Behaviors
{
    public class OrdenTrabajoDetalleModificarValidator : AbstractValidator<OrdenTrabajoDetalleModificarCommand>
    {
        public OrdenTrabajoDetalleModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador del detalle es obligatorio.");
            Include(new OrdenTrabajoDetalleGenericValidator<OrdenTrabajoDetalleModificarCommand>());
        }
    }
}
