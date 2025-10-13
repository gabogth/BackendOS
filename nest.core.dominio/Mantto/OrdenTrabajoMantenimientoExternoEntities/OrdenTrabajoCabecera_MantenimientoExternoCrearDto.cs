using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.dominio.Mantto.OrdenTrabajoMantenimientoExternoEntities
{
    /// <summary>
    /// DTO compuesto para registrar una orden de trabajo de mantenimiento externo con sus detalles y activos.
    /// </summary>
    public class OrdenTrabajoCabecera_MantenimientoExternoCrearDto
    {
        /// <summary>
        /// Datos de la cabecera de la orden de trabajo.
        /// </summary>
        [Required]
        public OrdenTrabajoCabeceraCrearDto Cabecera { get; set; }

        /// <summary>
        /// Lista de detalles asociados a la orden de trabajo.
        /// </summary>
        public List<OrdenTrabajoDetalle_MantenimientoExternoCrearDto> Detalles { get; set; } = new();
    }
}
