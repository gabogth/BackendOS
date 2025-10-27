using System.Collections.Generic;
using nest.core.aplicacion.general.Personas.Commands;

namespace nest.core.aplicacion.general.PersonaUseCases.Commands
{
    public interface IPersonaAdjuntosUseCaseCommand : IPersonaGenericCommand
    {
        IReadOnlyCollection<PersonaAdjuntoItemCommand>? PersonaAdjuntos { get; }
    }
}
