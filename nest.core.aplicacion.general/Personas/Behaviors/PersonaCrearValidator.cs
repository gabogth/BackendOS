using FluentValidation;
using nest.core.aplicacion.general.Personas.Commands;

namespace nest.core.aplicacion.general.Personas.Behaviors
{
    public class PersonaCrearValidator : AbstractValidator<PersonaCrearCommand>
    {
        public PersonaCrearValidator()
        {
            Include(new PersonaGenericValidator<PersonaCrearCommand>());
        }
    }
}
