using FluentValidation;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Commands;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Behaviors
{
    public class GrupoTrabajoEliminarValidator : AbstractValidator<GrupoTrabajoEliminarCommand>
    {
        public GrupoTrabajoEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es obligatorio.");
        }
    }
}
