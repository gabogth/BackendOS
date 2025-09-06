using nest.core.dominio.General.ProvinciaEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.General.DistritoEntities
{
    public class Distrito : IAuditable, IEntity<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProvinciaId { get; set; }

        public Provincia Provincia { get; set; }
    }
}
