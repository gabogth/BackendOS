using nest.core.dominio.Mantto.LaborEntities;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities
{
    public class OrdenTrabajoDetalle : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public long OrdenTrabajoCabeceraId { get; set; }
        public long UbicacionTecnicaId { get; set; }
        public int LaborId { get; set; }
        public int HorasProyectadas { get; set; }
        public int HorasEjecutadas { get; set; }
        public string Descripcion { get; set; }
        public OrdenTrabajoDetalleEstado Estado { get; set; }
        public OrdenTrabajoCabecera OrdenTrabajoCabecera { get; set; }
        public UbicacionTecnica UbicacionTecnica { get; set; }
        public Labor Labor { get; set; }
    }

    public enum OrdenTrabajoDetalleEstado : byte
    {
        Activo = 0,
        EnProceso = 1,
        Cancelado = 2,
        Detenido = 3,
        Terminado = 4,
    }
}
