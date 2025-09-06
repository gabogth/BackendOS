using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.dominio.RRHH.HorarioCabeceraEntities
{
    public class HorarioDto
    {
        public HorarioCabeceraCrearDto Cabecera { get; set; }
        public List<HorarioDetalleCrearDto> Detalles { get; set; } = new();
    }
}
