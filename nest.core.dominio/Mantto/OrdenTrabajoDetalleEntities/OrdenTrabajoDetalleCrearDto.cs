using System.ComponentModel.DataAnnotations;

namespace nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities
{
    public class OrdenTrabajoDetalleCrearDto
    {
        [Required]
        public int EmpresaId { get; set; }
        [Required]
        public long OrdenTrabajoCabeceraId { get; set; }
        [Required]
        public long UbicacionTecnicaId { get; set; }
        [Required]
        public int LaborId { get; set; }
        public int HorasProyectadas { get; set; }
        public int HorasEjecutadas { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public OrdenTrabajoDetalleEstado Estado { get; set; }
    }
}
