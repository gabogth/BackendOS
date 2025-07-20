namespace nest.core.dominio.Finanzas.ClienteEntities
{
    public class TerceroCrearDto
    {
        public byte DocumentoIdentidadTipoFinancieroId { get; set; }
        public string DocumentoIdentidadFinanciero { get; set; }
        public string RazonSocial { get; set; }
        public string DireccionFiscal { get; set; }
        public int CuentaContablePorCobrarId { get; set; }
        public int CuentaContablePorPagarId { get; set; }
    }
}
