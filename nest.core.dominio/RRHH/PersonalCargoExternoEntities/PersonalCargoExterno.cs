using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.PersonalCargoExternoEntities
{
    public class PersonalCargoExterno : IAuditable, IEntity<long>, ITenantEntity
    {
        public long Id { get; set; }
        public int EmpresaId { get; set; }
        public int PersonalId { get; set; }
        public int CargoId { get; set; }
        public Personal Personal { get; set; }
        public Cargo Cargo { get; set; }
    }
}
