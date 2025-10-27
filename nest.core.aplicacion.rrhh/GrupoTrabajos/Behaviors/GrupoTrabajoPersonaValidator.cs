using FluentValidation;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Commands;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Behaviors
{
    public class GrupoTrabajoPersonaValidator : AbstractValidator<GrupoTrabajoPersonaCommand>
    {
        public GrupoTrabajoPersonaValidator()
        {
            RuleFor(x => x.PersonaId)
                .GreaterThan(0).WithMessage("La persona es obligatoria.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("La empresa es obligatoria.");
        }
    }
}
