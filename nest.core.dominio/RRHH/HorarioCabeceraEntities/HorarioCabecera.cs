using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.HorarioCabeceraEntities
{
    public class HorarioCabecera : IAuditable, IEntity<int>, ITenantEntity
    {
        public int EmpresaId { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int? MinutosDescanso { get; set; }
        public int? MinutosTraslado { get; set; }
        public List<HorarioDetalle> HorarioDetalles { get; set; }
        public List<OrdenTrabajoHorario> OrdenTrabajoHorarios { get; set; }
    }
}
