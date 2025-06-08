using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.General.DocumentoTipoEntities
{
    public class DocumentoTipo : IAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string CodigoEstatal { get; set; }
    }
}
