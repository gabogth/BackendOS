using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajo.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Behaviors
{
    public class OTMantenimientoExternoModificarValidator : AbstractValidator<OTMantenimientoExternoModificarCommand>
    {
        public OTMantenimientoExternoModificarValidator()
        {
            //Include(new OTMantenimientoExternoGenericValidator<OTMantenimientoExternoModificarCommand>());

            //RuleFor(x => x.Id)
            //    .GreaterThan(0);
        }
    }
}
