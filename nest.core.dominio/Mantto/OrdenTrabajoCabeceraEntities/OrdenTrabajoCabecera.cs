using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities
{
    public class OrdenTrabajoCabecera : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public long OrdenServicioCabeceraId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCompromiso { get; set; }
        public DateTime? FechaFin { get; set; }
        public long? GrupoTrabajoId { get; set; }
        public long? OrdenTrabajoCabeceraPadreId { get; set; }
        public OrdenTrabajoEstado Estado { get; set; }
        public OrdenServicioCabecera OrdenServicioCabecera { get; set; }
        public OrdenTrabajoCabecera OrdenTrabajoCabeceraPadre { get; set; }
        public GrupoTrabajo GrupoTrabajo { get; set; }
        public List<OrdenTrabajoCabecera> Children { get; set; }
        public List<OrdenTrabajoDetalle> OrdenTrabajoDetalles { get; set; }
    }

    public enum OrdenTrabajoEstado : byte
    {
        Activo = 0,
        EnProceso = 1,
        Cancelado = 2,
        Detenido = 3,
        Terminado = 4,
    }
}
