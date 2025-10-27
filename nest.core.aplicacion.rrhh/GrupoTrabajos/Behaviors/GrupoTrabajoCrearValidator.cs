using FluentValidation;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Commands;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Behaviors
{
    public class GrupoTrabajoCrearValidator : AbstractValidator<GrupoTrabajoCrearCommand>
    {
        public GrupoTrabajoCrearValidator()
        {
            Include(new GrupoTrabajoGenericValidator<GrupoTrabajoCrearCommand>());
        }
    }
}
