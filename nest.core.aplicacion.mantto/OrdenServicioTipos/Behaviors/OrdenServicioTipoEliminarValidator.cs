using FluentValidation;
using nest.core.aplicacion.mantto.OrdenServicioTipos.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioTipos.Behaviors
{
    public class OrdenServicioTipoEliminarValidator : AbstractValidator<OrdenServicioTipoEliminarCommand>
    {
        public OrdenServicioTipoEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan((short)0).WithMessage("El identificador debe ser mayor a 0.");
        }
    }
}
