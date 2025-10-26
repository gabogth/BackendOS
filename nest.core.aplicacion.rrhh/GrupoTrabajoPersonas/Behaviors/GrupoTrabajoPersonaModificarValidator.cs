using FluentValidation;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Behaviors;

public class GrupoTrabajoPersonaModificarValidator : AbstractValidator<GrupoTrabajoPersonaModificarCommand>
{
    public GrupoTrabajoPersonaModificarValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El identificador es obligatorio.");

        Include(new GrupoTrabajoPersonaCrearValidator());
    }
}
