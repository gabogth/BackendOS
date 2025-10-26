using FluentValidation;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Behaviors;

public class GrupoTrabajoPersonaEliminarValidator : AbstractValidator<GrupoTrabajoPersonaEliminarCommand>
{
    public GrupoTrabajoPersonaEliminarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");
    }
}
