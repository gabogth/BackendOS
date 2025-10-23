using System.Collections.Generic;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.dominio.General.PersonaEntities
{
    public class PersonaAdjuntosUseCaseCrearDto
    {
        public PersonaCrearDto Persona { get; set; }
        public List<PersonaAdjuntoCrearDto> PersonaAdjuntos { get; set; } = new();
    }
}
