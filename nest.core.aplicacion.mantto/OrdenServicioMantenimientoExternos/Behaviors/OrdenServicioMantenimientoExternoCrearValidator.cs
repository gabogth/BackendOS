using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Behaviors
{
    public class OrdenServicioMantenimientoExternoCrearValidator : AbstractValidator<OrdenServicioMantenimientoExternoCrearCommand>
    {
        public OrdenServicioMantenimientoExternoCrearValidator()
        {
            Include(new OrdenServicioMantenimientoExternoGenericValidator<OrdenServicioMantenimientoExternoCrearCommand>());
        }
    }
}
