using nest.core.dominio.Corporativo;
using nest.core.dominio.RRHH;

namespace nest.core.dominio.Legal
{
    public class ContratoPersonal
    {
        public int ContratoCabeceraId { get; set; }
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
