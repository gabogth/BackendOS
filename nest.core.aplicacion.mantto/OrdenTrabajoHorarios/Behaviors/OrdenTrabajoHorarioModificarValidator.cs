using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Behaviors
{
    public class OrdenTrabajoHorarioModificarValidator : AbstractValidator<OrdenTrabajoHorarioModificarCommand>
    {
        public OrdenTrabajoHorarioModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador debe ser mayor a 0.");

            Include(new OrdenTrabajoHorarioGenericValidator<OrdenTrabajoHorarioModificarCommand>());
        }
    }
}
