using FluentValidation;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Behaviors;

public class GrupoTrabajoPersonaCrearValidator : AbstractValidator<GrupoTrabajoPersonaCrearCommand>
{
    public GrupoTrabajoPersonaCrearValidator()
    {
        RuleFor(x => x.EmpresaId)
            .GreaterThan(0).WithMessage("La empresa es obligatoria.");

        RuleFor(x => x.GrupoTrabajoId)
            .GreaterThan(0).WithMessage("El grupo de trabajo es obligatorio.");

        RuleFor(x => x.PersonaId)
            .GreaterThan(0).WithMessage("La persona es obligatoria.");
    }
}
