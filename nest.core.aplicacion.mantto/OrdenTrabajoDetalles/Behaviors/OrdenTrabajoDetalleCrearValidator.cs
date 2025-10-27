using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Behaviors
{
    public class OrdenTrabajoDetalleCrearValidator : AbstractValidator<OrdenTrabajoDetalleCrearCommand>
    {
        public OrdenTrabajoDetalleCrearValidator()
        {
            Include(new OrdenTrabajoDetalleGenericValidator<OrdenTrabajoDetalleCrearCommand>());
        }
    }
}
