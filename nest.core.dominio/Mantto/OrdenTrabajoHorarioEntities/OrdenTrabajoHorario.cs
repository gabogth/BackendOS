using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities
{
    public class OrdenTrabajoHorario : IEntity<long>, IAuditable, ITenantEntity
    {
        public long Id { get; set; }
        public int EmpresaId { get; set; }
        public long OrdenTrabajoCabeceraId { get; set; }
        public int PersonalId { get; set; }
        public DateOnly Fecha { get; set; }
        public int HorarioCabeceraId { get; set; }
        public OrdenTrabajoCabecera OrdenTrabajoCabecera { get; set; }
        public Personal Personal { get; set; }
        public HorarioCabecera HorarioCabecera { get; set; }

    }
}
