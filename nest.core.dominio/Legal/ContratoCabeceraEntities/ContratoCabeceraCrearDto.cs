namespace nest.core.dominio.Legal.ContratoCabeceraEntities
{
    public class ContratoCabeceraCrearDto
    {
        public byte ContratoTipoId { get; set; }
        public int Numero { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public bool Estado { get; set; }
        public string Observacion { get; set; }
        public string Resumen { get; set; }
        public string Descripcion { get; set; }
    }
}
