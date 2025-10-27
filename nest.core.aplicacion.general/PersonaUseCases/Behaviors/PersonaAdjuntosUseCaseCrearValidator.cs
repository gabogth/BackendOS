using FluentValidation;
using nest.core.aplicacion.general.PersonaUseCases.Commands;

namespace nest.core.aplicacion.general.PersonaUseCases.Behaviors
{
    public class PersonaAdjuntosUseCaseCrearValidator : AbstractValidator<PersonaAdjuntosUseCaseCrearCommand>
    {
        public PersonaAdjuntosUseCaseCrearValidator()
        {
            Include(new PersonaAdjuntosUseCaseGenericValidator<PersonaAdjuntosUseCaseCrearCommand>());
        }
    }
}
