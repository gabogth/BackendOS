using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Behaviors
{
    public class OrdenTrabajoDetalleActivoModificarValidator : AbstractValidator<OrdenTrabajoDetalleActivoModificarCommand>
    {
        public OrdenTrabajoDetalleActivoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador del registro es obligatorio.");
            Include(new OrdenTrabajoDetalleActivoGenericValidator<OrdenTrabajoDetalleActivoModificarCommand>());
        }
    }
}
