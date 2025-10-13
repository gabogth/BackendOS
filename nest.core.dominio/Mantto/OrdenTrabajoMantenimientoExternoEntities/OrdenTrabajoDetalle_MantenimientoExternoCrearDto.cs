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
        /// Identificador del detalle existente. Si es nulo, se creará un nuevo registro.
        /// </summary>
        public long? DetalleId { get; set; }

        /// <summary>
        /// Información del detalle de la orden de trabajo.
        /// </summary>
        [Required]
        public OrdenTrabajoDetalleCrearDto Detalle { get; set; }

        /// <summary>
        /// Identificador del activo asociado al detalle. Si es nulo se creará un nuevo registro.
        /// </summary>
        public long? DetalleActivoId { get; set; }

        /// <summary>
        /// Información del activo asociado al detalle de la orden de trabajo.
        /// </summary>
        public OrdenTrabajoDetalleActivoCrearDto? Activo { get; set; }
    }
}
