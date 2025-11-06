using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.PersonalEstadoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.RRHH.PersonalEntities
{
    public class Personal : IAuditable, IEntity<int>, ITenantEntity
    {
        public int EmpresaId { get; set; }
        public int Id { get; set; }
        public bool MarcaAsistencia { get; set; }
        public long ContratoCabeceraId { get; set; }
        public int HorarioCabeceraId { get; set; }
        public int? SuperiorId { get; set; }
        public byte PersonalEstadoId { get; set; }
        public long RegistroAsistenciaPoliticaId { get; set; }
        public string UsuarioId { get; set; }
        public HorarioCabecera HorarioCabecera { get; set; }
        public RegistroAsistenciaPolitica RegistroAsistenciaPolitica { get; set; }
        public ContratoCabecera ContratoCabecera { get; set; }
        public Persona Persona { get; set; }
        public PersonalEstado PersonalEstado { get; set; }
        public Personal Superior { get; set; }
        public List<Personal> Children { get; set; }
        public ApplicationUser Usuario { get; set; }
        public List<OrdenTrabajoHorario> OrdenTrabajoHorarios { get; set; }
    }
}
