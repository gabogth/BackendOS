using nest.core.dominio.Security.Audit;
using nest.core.dominio;

namespace nest.core.dominio.General.LicenciaConducirEntities
{
    public class LicenciaConducir : IAuditable, IEntity<byte>
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public byte Nivel { get; set; }
    }
}
