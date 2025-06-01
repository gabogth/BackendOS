using nest.core.dominio.General;
using System.ComponentModel.DataAnnotations;

namespace nest.core.dominio.RRHH
{
    public class Personal
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string? CelularEmpresa { get; set; }
        [EmailAddress]
        public string? CorreoEmpresa { get; set; }
        public int? JefeId { get; set; }
        public Personal Jefe { get; set; }
        public Persona Persona { get; set; }
        public ICollection<Personal> Children { get; set; } = new List<Personal>();
    }
}
