using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.Legal.ContratoCabeceraEntities;

namespace nest.core.dominio.Legal.ContratoDetalleEntities
{
    public class ContratoDetalle
    {
        public long Id { get; set; }
        public long ContratoCabeceraId { get; set; }
        public int PersonaId { get; set; }
        public DateTime? FechaUltimaNotificacion { get; set; }
        public bool Firmo { get; set; }
        public DateTime? FechaFirma { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public ContratoCabecera ContratoCabecera { get; set; }
        public Persona Persona { get; set; }
    }
}
