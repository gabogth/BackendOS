using nest.core.dominio.Finanzas.FinancieroDetalleEntities;
using nest.core.dominio.Logistica.Transaccional;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Finanzas.FinancieroLogisticaEntities
{
    public class FinancieroLogistica : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public long FinancieroDetalleId { get; set; }
        public long InventarioCabeceraId { get; set; }
        public FinancieroDetalle FinancieroDetalle { get; set; }
        public InventarioCabecera InventarioCabecera { get; set; }
    }
}
