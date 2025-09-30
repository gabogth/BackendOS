using System.Collections.Generic;
using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.dominio.RRHH.HorarioCabeceraEntities
{
    public class HorarioDto
    {
        /// <summary>
        /// Información de la cabecera del horario.
        /// </summary>
        public HorarioCabeceraCrearDto Cabecera { get; set; }

        /// <summary>
        /// Lista jerárquica de detalles que incluye sus eventos asociados.
        /// </summary>
        public List<HorarioDetalleCrearDto> Detalles { get; set; } = new();
    }
}
