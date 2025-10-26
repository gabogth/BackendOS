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

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("El identificador de la empresa es obligatorio.");

            RuleFor(x => x.OrdenTrabajoDetalleId)
                .GreaterThan(0).WithMessage("El identificador del detalle es obligatorio.");

            RuleFor(x => x.ActivoId)
                .GreaterThan(0).WithMessage("El identificador del activo es obligatorio.");
        }
    }
}
