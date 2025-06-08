using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.General.DocumentoIdentidadTipoEntities
{
    public class DocumentoIdentidadTipo : IAuditable
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
    }
}
