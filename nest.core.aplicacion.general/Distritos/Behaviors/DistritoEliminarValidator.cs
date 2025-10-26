using FluentValidation;
using nest.core.aplicacion.general.Distritos.Commands;

namespace nest.core.aplicacion.general.Distritos.Behaviors
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
