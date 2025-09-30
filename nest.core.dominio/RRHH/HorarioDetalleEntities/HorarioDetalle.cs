using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.HorarioDetalleEntities
{
    public static class DayOfWeekUtils
    {
        public static DayOfWeek Ayer(DayOfWeek now)
        {
            if (now == DayOfWeek.Sunday) return DayOfWeek.Saturday;
            return now - 1;
        }
        public static DayOfWeek Manana(DayOfWeek now)
        {
            if (now == DayOfWeek.Saturday) return DayOfWeek.Sunday;
            return now + 1;
        }
    }
    public class HorarioDetalle : IAuditable, IEntity<long>, ITenantEntity
    {
        public int EmpresaId { get; set; }
        public long Id { get; set; }
        public int Item { get; set; }
        public int HorarioCabeceraId { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public HorarioCabecera HorarioCabecera { get; set; }
        public List<HorarioDetalleEvento> HorarioDetalleEventos { get; set; }
    }
}
