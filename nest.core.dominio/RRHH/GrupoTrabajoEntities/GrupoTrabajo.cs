using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.GrupoTrabajoEntities
{
    public class GrupoTrabajo : IEntity<long>, IAuditable, ITenantEntity
    {
        public int EmpresaId { get; set; }
        public long Id { get; set; }
        public int Nombre { get; set; }
        public int NombreCorto { get; set; }
        public bool Estado { get; set; }
        public List<GrupoTrabajoPersona> GrupoTrabajoPersonas { get; set; }
    }
}
