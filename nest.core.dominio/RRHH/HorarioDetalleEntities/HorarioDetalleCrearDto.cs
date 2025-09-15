namespace nest.core.dominio.RRHH.HorarioDetalleEntities
{
    public class HorarioDetalleCrearDto
    {
        public int EmpresaId { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public int GrupoHorarioId { get; set; }
    }
}
