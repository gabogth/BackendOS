using FluentValidation;
using nest.core.aplicacion.general.PersonaUseCases.Commands;

namespace nest.core.aplicacion.general.PersonaUseCases.Behaviors
{
    public class PersonaAdjuntosUseCaseEliminarValidator : AbstractValidator<PersonaAdjuntosUseCaseEliminarCommand>
    {
        public PersonaAdjuntosUseCaseEliminarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador de la persona es requerido.");
        }
    }
}
