using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities
{
    public class RegistroAsistenciaOrdenTrabajo : IEntity<long>, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public int EmpresaId { get; set; }
        public long OrdenTrabajoCabeceraId { get; set; }
        public RegistroAsistencia RegistroAsistencia { get; set; }
        public OrdenTrabajoCabecera OrdenTrabajoCabecera { get; set; }

    }
}
