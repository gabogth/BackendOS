using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.dominio.RRHH.HorarioDetalleEntities
{
    public class HorarioDetalleCrearDto
    {
        public int EmpresaId { get; set; }
        public long? Id { get; set; }
        public int HorarioCabeceraId { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public List<HorarioDetalleEventoCrearDto> Eventos { get; set; } = new();
    }
}
