namespace nest.core.dominio.Finanzas.ClienteEntities
{
    public class TerceroCrearDto
    {
        public int EmpresaId { get; set; }
        public int Id { get; set; }
        public byte DocumentoIdentidadTipoFinancieroId { get; set; }
        public string DocumentoIdentidadFinanciero { get; set; }
        public string RazonSocial { get; set; }
        public string DireccionFiscal { get; set; }
        public long CuentaContablePorCobrarId { get; set; }
        public long CuentaContablePorPagarId { get; set; }
    }
}
