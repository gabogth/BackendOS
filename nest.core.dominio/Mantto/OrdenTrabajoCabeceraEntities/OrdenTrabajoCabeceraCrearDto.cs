using System.ComponentModel.DataAnnotations;

namespace nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities
{
    public class OrdenTrabajoCabeceraCrearDto
    {
        [Required]
        public int EmpresaId { get; set; }
        [Required]
        public long OrdenServicioCabeceraId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaCompromiso { get; set; }
        public DateTime? FechaFin { get; set; }
        public long? GrupoTrabajoId { get; set; }
        public long? OrdenTrabajoCabeceraPadreId { get; set; }
        [Required]
        public OrdenTrabajoEstado Estado { get; set; }
    }
}
