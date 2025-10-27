using FluentValidation;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Commands;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Behaviors
{
    public class GrupoTrabajoModificarValidator : AbstractValidator<GrupoTrabajoModificarCommand>
    {
        public GrupoTrabajoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es obligatorio.");

            Include(new GrupoTrabajoGenericValidator<GrupoTrabajoModificarCommand>());
        }
    }
}
