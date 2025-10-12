using System;

namespace nest.core.dominio.RRHH.HorarioDetalleEventoEntities
{
    public class HorarioDetalleEventoCrearDto
    {
        public long? Id { get; set; }
        public int EmpresaId { get; set; }
        public long HorarioDetalleId { get; set; }
        public HorarioDetalleEventoTipoEnum TipoEvento { get; set; }
        public TimeOnly Hora { get; set; }
        public int DiferenciaDia { get; set; }
        public int VentanaMin { get; set; }
        public int VentanaMax { get; set; }
    }
}
