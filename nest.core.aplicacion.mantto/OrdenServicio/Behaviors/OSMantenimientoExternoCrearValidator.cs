using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicio.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicio.Behaviors
{
    public class OSMantenimientoExternoCrearValidator : AbstractValidator<OSMantenimientoExternoCrearCommand>
    {
        public OSMantenimientoExternoCrearValidator()
        {
            Include(new OSMantenimientoExternoGenericValidator<OSMantenimientoExternoCrearCommand>());
        }
    }
}
