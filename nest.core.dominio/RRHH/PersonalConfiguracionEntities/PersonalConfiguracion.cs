using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.PersonalConfiguracionEntities
{
    public class PersonalConfiguracion : IAuditable
    {
        public int Id { get; set; }
        public long ContratoCabeceraId { get; set; }
        public bool MarcaAsistencia { get; set; }
        public int HorarioCabeceraId { get; set; }
        public HorarioCabecera HorarioCabecera { get; set; }
        public ContratoCabecera ContratoCabecera { get; set; }
        public Personal Personal { get; set; }
    }
}
