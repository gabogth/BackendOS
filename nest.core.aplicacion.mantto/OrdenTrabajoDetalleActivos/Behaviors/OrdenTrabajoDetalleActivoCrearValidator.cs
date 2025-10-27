using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Behaviors
{
    public class OrdenTrabajoDetalleActivoCrearValidator : AbstractValidator<OrdenTrabajoDetalleActivoCrearCommand>
    {
        public OrdenTrabajoDetalleActivoCrearValidator()
        {
            Include(new OrdenTrabajoDetalleActivoGenericValidator<OrdenTrabajoDetalleActivoCrearCommand>());
        }
    }
}
