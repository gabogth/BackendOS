namespace nest.core.dominio.Finanzas.FinancieroCabeceraEntities
{
    public class FinancieroCabeceraCrearDto
    {
        public int PuntoFinancieroId { get; set; }
        public int Numero { get; set; }
        public short OrigenFinancieroId { get; set; }
        public EstadoFinancieroEnum Estado { get; set; }
        public string Comentarios { get; set; }
        public int TerceroGenId { get; set; }
        public int DocumentoTipoGenId { get; set; }
        public string SerieDocumentoGen { get; set; }
        public string NumeroDocumentoGen { get; set; }
    }
}
