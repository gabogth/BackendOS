using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.dominio.Patrimonial.ActivoEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities
{
    public class OrdenTrabajoDetalleActivo : IEntity<long>, IAuditable, ITenantEntity
    {
        public int EmpresaId { get; set; }
        public long Id { get; set; }
        public long ActivoId { get; set; }
        public OrdenTrabajoDetalle OrdenTrabajoDetalle { get; set; }
        public Activo Activo { get; set; }
    }
}
