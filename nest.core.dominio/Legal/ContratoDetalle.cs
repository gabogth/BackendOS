using nest.core.dominio.General;

namespace nest.core.dominio.Legal
{
    public class ContratoDetalle
    {
        public int Id { get; set; }
        public int ContratoCabeceraId { get; set; }
        public int PersonaId { get; set; }
        public DateTime? FechaUltimaNotificacion { get; set; }
        public bool Firmo { get; set; }
        public DateTime? FechaFirma { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public ContratoCabecera ContratoCabecera { get; set; }
        public Persona Persona { get; set; }
    }
}
