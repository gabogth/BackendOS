using FluentValidation;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Commands;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Behaviors
{
    public class GrupoTrabajoGenericValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : IGrupoTrabajoGenericCommand
    {
        public GrupoTrabajoGenericValidator()
        {
            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("La empresa es obligatoria.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.");

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es obligatorio.");

            RuleFor(x => x.Personas)
                .NotNull().WithMessage("Debe registrar al menos una persona.");

            RuleForEach(x => x.Personas)
                .SetValidator(new GrupoTrabajoPersonaValidator());
        }
    }
}
