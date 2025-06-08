using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Aplicacion.Formulario
{
    public class Formulario : IAuditable
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int ModuloId { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public string Controlador { get; set; }
        public string Action { get; set; }
        public string Icono { get; set; }
        public string ClaimType { get; set; }
        public short Orden { get; set; }
        public bool Estado { get; set; }
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public Formulario Parent { get; set; }
        public Modulo.Modulo Modulo { get; set; }
        public ICollection<Formulario> Children { get; set; } = new List<Formulario>();
    }
}
