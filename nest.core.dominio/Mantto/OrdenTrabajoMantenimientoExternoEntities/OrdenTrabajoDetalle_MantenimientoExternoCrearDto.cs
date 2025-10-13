using System.ComponentModel.DataAnnotations;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.dominio.Mantto.OrdenTrabajoMantenimientoExternoEntities
{
    /// <summary>
    /// Representa un detalle de orden de trabajo con la información de su activo asociado.
    /// </summary>
    public class OrdenTrabajoDetalle_MantenimientoExternoCrearDto
    {
        /// <summary>
        /// Información del detalle de la orden de trabajo.
        /// </summary>
        [Required]
        public OrdenTrabajoDetalleCrearDto Detalle { get; set; }

        /// <summary>
        /// Información del activo asociado al detalle de la orden de trabajo.
        /// </summary>
        [Required]
        public OrdenTrabajoDetalleActivoCrearDto Activo { get; set; }
    }
}
