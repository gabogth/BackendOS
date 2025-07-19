using nest.core.dominio.Finanzas.ClienteEntities;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Finanzas.FinancieroCabeceraEntities
{
    public class FinancieroCabecera : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public int PuntoFinancieroId { get; set; }
        public int Numero { get; set; }
        public short OrigenFinancieroId { get; set; }
        public EstadoFinancieroEnum Estado { get; set; }
        public string Comentarios { get; set; }
        public int TerceroGenId { get; set; }
        public int DocumentoTipoGenId { get; set; }
        public string SerieDocumentoGen { get; set; }
        public string NumeroDocumentoGen { get; set; }
        public PuntoFinanciero PuntoFinanciero { get; set; }
        public OrigenFinanciero OrigenFinanciero { get; set; }
        public Tercero TerceroGen { get; set; }
        public DocumentoTipo DocumentoTipoGen { get; set; }
        public List<FinancieroDetalle> FinancieroDetalles { get; set; }
    }
    public enum EstadoFinancieroEnum : byte
    {
        Activo = 1,
        PendienteRevision = 2,
        Cerrado = 3
    }
}
