using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Behaviors
{
    public class OrdenTrabajoPersonalEliminarValidator : AbstractValidator<OrdenTrabajoPersonalEliminarCommand>
    {
        public OrdenTrabajoPersonalEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador del registro es obligatorio.");
        }
    }
}
