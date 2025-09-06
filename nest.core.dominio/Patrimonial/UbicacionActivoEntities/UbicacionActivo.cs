using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.Patrimonial.ActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Patrimonial.UbicacionActivoEntities
{
    public class UbicacionActivo : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public long ActivoId { get; set; }
        public long UbicacionTecnicaId { get; set; }
        public string Comentario { get; set; }
        public long? ContratoCabeceraId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public Activo Activo { get; set; }
        public UbicacionTecnica UbicacionTecnica { get; set; }
        public ContratoCabecera ContratoCabecera { get; set; }
    }
}
