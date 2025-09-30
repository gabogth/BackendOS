using System;
using System.Collections.Generic;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.dominio.RRHH.HorarioDetalleEntities
{
    public class HorarioDetalleCrearDto
    {
        public int EmpresaId { get; set; }
        public int Item { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public List<HorarioDetalleEventoCrearDto> Eventos { get; set; } = new();
    }
}
