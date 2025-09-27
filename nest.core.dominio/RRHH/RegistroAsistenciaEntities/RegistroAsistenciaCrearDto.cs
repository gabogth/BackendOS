using System;

namespace nest.core.dominio.RRHH.RegistroAsistenciaEntities
{
    public class RegistroAsistenciaCrearDto
    {
        public int EmpresaId { get; set; }
        public long Id { get; set; }
        public int PersonalId { get; set; }
        public int GrupoHorarioId { get; set; }
        public DateTime Fecha { get; set; }
        public int DiferenciaMinutos { get; set; }
        public long HorarioDetalleId { get; set; }
    }
}
