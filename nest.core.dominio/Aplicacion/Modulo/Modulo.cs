using nest.core.dominio.Security.Audit;
using nest.core.dominio;

namespace nest.core.dominio.Aplicacion.Modulo
{
    public class Modulo : IAuditable, IEntity<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen { get; set; }
        public string Action { get; set; }
        public string Controlador { get; set; }
        public bool Estado { get; set; }
    }
}
