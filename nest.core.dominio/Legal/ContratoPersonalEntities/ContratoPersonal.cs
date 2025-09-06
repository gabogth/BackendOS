using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Legal.ContratoPersonalEntities
{
    public class ContratoPersonal : IAuditable
    {
        public long ContratoCabeceraId { get; set; }
        public int PersonaId { get; set; }
        public int CargoId { get; set; }
        public int EstructuraOrganizacionalId { get; set; }
        public decimal MontoBruto { get; set; }
        public Persona Persona { get; set; }
        public Cargo Cargo { get; set; }
        public EstructuraOrganizacional EstructuraOrganizacional { get; set; }
        public ContratoCabecera ContratoCabecera { get; set; }
    }
}
