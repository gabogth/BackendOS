using nest.core.dominio.RRHH.GrupoHorarioEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.RegistroAsistenciaEntities
{
    public class RegistroAsistencia: IEntity<long>, ITenantEntity, IAuditable
    {
        public int EmpresaId { get; set; }
        public long Id { get; set; }
        public int PersonalId { get; set; }
        public int GrupoHorarioId { get; set; }
        public DateTime Fecha { get; set; }
        public int DiferenciaMinutos { get; set; }
        public long HorarioDetalleId { get; set; }
        public GrupoHorario GrupoHorario { get; set; }
        public Personal Personal { get; set; }
        public HorarioDetalle HorarioDetalle { get; set; }
    }
}
