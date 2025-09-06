using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities
{
    public class GrupoTrabajoPersona : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public long GrupoTrabajoId { get; set; }
        public int PersonaId { get; set; }
        public bool EsLider { get; set; }
        public Persona Persona { get; set; }
        public GrupoTrabajo GrupoTrabajo { get; set; }
    }
}
