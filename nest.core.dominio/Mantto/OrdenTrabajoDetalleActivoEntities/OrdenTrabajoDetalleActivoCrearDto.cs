using System.ComponentModel.DataAnnotations;

namespace nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities
{
    public class OrdenTrabajoDetalleActivoCrearDto
    {
        [Required]
        public int EmpresaId { get; set; }
        [Required]
        public long OrdenTrabajoDetalleId { get; set; }
        [Required]
        public long ActivoId { get; set; }
    }
}
