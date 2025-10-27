using FluentValidation;
using nest.core.aplicacion.general.PersonaAdjuntos.Commands;

namespace nest.core.aplicacion.general.PersonaAdjuntos.Behaviors
{
    public sealed class PersonaAdjuntoCrearValidator : AbstractValidator<PersonaAdjuntoCrearCommand>
    {
        public PersonaAdjuntoCrearValidator()
        {
            Include(new PersonaAdjuntoGenericValidator<PersonaAdjuntoCrearCommand>());
        }
    }
}
