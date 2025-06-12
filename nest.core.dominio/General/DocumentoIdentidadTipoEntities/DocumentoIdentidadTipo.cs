using nest.core.dominio.Security.Audit;
using nest.core.dominio;

namespace nest.core.dominio.General.DocumentoIdentidadTipoEntities
{
    public class DocumentoIdentidadTipo : IAuditable, IEntity<byte>
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
    }
}
