using FluentValidation;
using nest.core.aplicacion.general.Personas.Commands;

namespace nest.core.aplicacion.general.Personas.Behaviors
{
    public class PersonaEliminarValidator : AbstractValidator<PersonaEliminarCommand>
    {
        public PersonaEliminarValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id es requerido.");
        }
    }
}
