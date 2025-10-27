using FluentValidation;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Behaviors;

public class GrupoTrabajoPersonaCrearValidator : AbstractValidator<GrupoTrabajoPersonaCrearCommand>
{
    public GrupoTrabajoPersonaCrearValidator()
    {
        Include(new GrupoTrabajoPersonaGenericValidator<GrupoTrabajoPersonaCrearCommand>());
    }
}
