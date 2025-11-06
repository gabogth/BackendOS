using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajo.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Behaviors
{
    public class OTMantenimientoExternoCrearValidator : AbstractValidator<OTMantenimientoExternoCrearCommand>
    {
        public OTMantenimientoExternoCrearValidator()
        {
            //Include(new OTMantenimientoExternoGenericValidator<OTMantenimientoExternoCrearCommand>());
        }
    }
}
