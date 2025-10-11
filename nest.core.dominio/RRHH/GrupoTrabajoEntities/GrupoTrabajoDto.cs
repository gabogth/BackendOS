using System.Collections.Generic;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.dominio.RRHH.GrupoTrabajoEntities
{
    public class GrupoTrabajoDto
    {
        public GrupoTrabajoCrearDto Cabecera { get; set; } = new();
        public List<GrupoTrabajoPersonaCrearDto> Personas { get; set; } = new();
    }
}
