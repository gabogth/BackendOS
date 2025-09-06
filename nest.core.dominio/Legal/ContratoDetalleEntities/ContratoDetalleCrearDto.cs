namespace nest.core.dominio.Legal.ContratoDetalleEntities
{
    public class ContratoDetalleCrearDto
    {
        public int PersonaId { get; set; }
        public DateTime? FechaUltimaNotificacion { get; set; }
        public bool Firmo { get; set; }
        public DateTime? FechaFirma { get; set; }
        public string Observacion { get; set; }
    }
}
