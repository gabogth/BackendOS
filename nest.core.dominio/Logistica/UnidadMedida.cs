using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Logistica
{
    public class UnidadMedida : IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Prefix { get; set; }
    }
}
