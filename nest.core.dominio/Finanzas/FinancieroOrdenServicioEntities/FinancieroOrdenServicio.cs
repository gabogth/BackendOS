using nest.core.dominio.Finanzas.FinancieroDetalleEntities;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Finanzas.FinancieroOrdenServicioEntities
{
    public class FinancieroOrdenServicio : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public long FinancieroDetalleId { get; set; }
        public long OrdenServicioCabeceraId { get; set; }
        public FinancieroDetalle FinancieroDetalle { get; set; }
        public OrdenServicioCabecera OrdenServicioCabecera { get; set; }
    }
}
