using nest.core.dominio.RRHH.GrupoHorarioEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.HorarioDetalleEntities
{
    public enum DayOfWeek: byte
    {
        Domingo = 0,
        Lunes = 1,
        Martes = 2,
        Miercoles = 3,
        Jueves = 4,
        Viernes = 5,
        Sabado = 6
    }
    public class HorarioDetalle : IAuditable, IEntity<int>
    {
        public int Id { get; set; }
        public int HorarioCabeceraId { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public int GrupoHorarioId { get; set; }
        public HorarioCabecera HorarioCabecera { get; set; }
        public GrupoHorario GrupoHorario { get; set; }
    }
}
