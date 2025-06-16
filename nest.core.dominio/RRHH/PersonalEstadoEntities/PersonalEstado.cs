using nest.core.dominio.Security.Audit;
using nest.core.dominio;

namespace nest.core.dominio.RRHH.PersonalEstadoEntities
{
    public class PersonalEstado : IAuditable, IEntity<byte>
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
    }
}
