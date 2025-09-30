using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.dominio.RRHH.RegistroAsistenciaEntities
{
    public class RegistroAsistenciaCrearDto
    {
        public int EmpresaId { get; set; }
        public int PersonalId { get; set; }
        public int? GrupoHorarioId { get; set; }
        public DateTime Fecha { get; set; }
        public DateOnly FechaJornal { get; set; }
        public HorarioDetalleEventoTipoEnum TipoMarca { get; set; }
        public bool EsTardanza { get; set; }
        public int DiferenciaMinutos { get; set; }
        public long? HorarioDetalleId { get; set; }
    }
}
