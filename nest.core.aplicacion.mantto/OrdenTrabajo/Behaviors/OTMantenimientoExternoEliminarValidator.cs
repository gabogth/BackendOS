using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajo.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Behaviors
{
    public class OTMantenimientoExternoEliminarValidator : AbstractValidator<OTMantenimientoExternoEliminarCommand>
    {
        public OTMantenimientoExternoEliminarValidator()
        {
            //RuleFor(x => x.Id)
                //.GreaterThan(0);
        }
    }
}
