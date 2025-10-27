using FluentValidation;
using nest.core.aplicacion.general.PersonaAdjuntos.Commands;

namespace nest.core.aplicacion.general.PersonaAdjuntos.Behaviors
{
    public sealed class PersonaAdjuntoModificarValidator : AbstractValidator<PersonaAdjuntoModificarCommand>
    {
        public PersonaAdjuntoModificarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El identificador es requerido.");
            Include(new PersonaAdjuntoGenericValidator<PersonaAdjuntoModificarCommand>());
        }
    }
}
