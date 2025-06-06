using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;
using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.dominio.Legal.ContratoPersonalEntities
{
    public class ContratoPersonal
    {
        public long ContratoCabeceraId { get; set; }
        public int PersonalId { get; set; }
        public int CargoId { get; set; }
        public int EstructuraOrganizacionalId { get; set; }
        public decimal MontoBruto { get; set; }
        public Personal Personal { get; set; }
        public Cargo Cargo { get; set; }
        public EstructuraOrganizacional EstructuraOrganizacional { get; set; }
        public ContratoCabecera ContratoCabecera { get; set; }
    }
}
