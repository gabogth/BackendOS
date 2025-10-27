using FluentValidation;
using nest.core.aplicacion.general.PersonaUseCases.Commands;
using nest.core.aplicacion.general.Personas.Behaviors;

namespace nest.core.aplicacion.general.PersonaUseCases.Behaviors
{
    public class PersonaAdjuntosUseCaseGenericValidator<TCommand> : PersonaGenericValidator<TCommand>
        where TCommand : IPersonaAdjuntosUseCaseCommand
    {
        public PersonaAdjuntosUseCaseGenericValidator()
        {
            When(x => x.PersonaAdjuntos is not null, () =>
            {
                RuleForEach(x => x.PersonaAdjuntos!)
                    .SetValidator(new PersonaAdjuntoItemValidator());
            });
        }
    }
}
