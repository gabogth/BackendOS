using FluentValidation;
using nest.core.aplicacion.general.PersonaUseCases.Commands;

namespace nest.core.aplicacion.general.PersonaUseCases.Behaviors
{
    public class PersonaAdjuntosUseCaseModificarValidator : AbstractValidator<PersonaAdjuntosUseCaseModificarCommand>
    {
        public PersonaAdjuntosUseCaseModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador de la persona es requerido.");
            Include(new PersonaAdjuntosUseCaseGenericValidator<PersonaAdjuntosUseCaseModificarCommand>());
        }
    }
}
