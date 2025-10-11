using System.ComponentModel.DataAnnotations;

namespace nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities
{
    public class OrdenTrabajoPersonalCrearDto
    {
        [Required]
        public int EmpresaId { get; set; }
        [Required]
        public long OrdenTrabajoCabeceraId { get; set; }
        [Required]
        public int PersonaId { get; set; }
        public bool EsLider { get; set; }
    }
}
