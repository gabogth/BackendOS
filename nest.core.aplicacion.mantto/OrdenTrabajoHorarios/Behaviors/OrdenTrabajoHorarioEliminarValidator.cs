using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Behaviors
{
    public class OrdenTrabajoHorarioEliminarValidator : AbstractValidator<OrdenTrabajoHorarioEliminarCommand>
    {
        public OrdenTrabajoHorarioEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a 0.");
        }
    }
}
