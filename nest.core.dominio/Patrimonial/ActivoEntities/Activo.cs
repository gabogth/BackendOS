using nest.core.dominio.Logistica;
using nest.core.dominio.Finanzas.ClienteEntities;
using nest.core.dominio.Costos.CentroDeCostosEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Patrimonial.ActivoEntities
{
    public class Activo : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public long? ProductoLoteId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? DepreciacionMeses { get; set; }
        public int? CentroDeCostosId { get; set; }
        public string ImagenUrl { get; set; }
        public int? TerceroId { get; set; }
        public ProductoLote ProductoLote { get; set; }
        public CentroDeCostos CentroDeCostos { get; set; }
        public Tercero Tercero { get; set; }
    }
}
