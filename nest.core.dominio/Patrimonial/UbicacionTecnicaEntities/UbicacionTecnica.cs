using nest.core.dominio.Finanzas.ClienteEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Patrimonial.UbicacionTecnicaEntities
{
    public class UbicacionTecnica : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public int? TerceroId { get; set; }
        public long? PadreId { get; set; }
        public Tercero Tercero { get; set; }
        public UbicacionTecnica Padre { get; set; }
        public List<UbicacionTecnica> Children { get; set; }
    }
}
