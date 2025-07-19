using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities
{
    public class OrdenTrabajoPersonal : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public long OrdenTrabajoCabeceraId { get; set; }
        public int PersonaId { get; set; }
        public bool EsLider { get; set; }
        public OrdenTrabajoCabecera OrdenTrabajoCabecera { get; set; }
        public Persona Persona { get; set; }
    }
}
