using nest.core.dominio.RRHH.GrupoHorarioEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.HorarioDetalleEntities
{
    public class HorarioDetalle : IAuditable
    {
        public int Id { get; set; }
        public int HorarioCabeceraId { get; set; }
        public short Item { get; set; }
        public byte DiaSemana { get; set; }
        public int GrupoHorarioId { get; set; }
        public HorarioCabecera HorarioCabecera { get; set; }
        public GrupoHorario GrupoHorario { get; set; }
    }
}
