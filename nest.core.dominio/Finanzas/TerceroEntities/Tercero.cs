using nest.core.dominio.Contabilidad.CuentaContableEntities;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Finanzas.ClienteEntities
{
    public class Tercero : IEntity<int>, IAuditable
    {
        public int Id { get; set; }
        public byte DocumentoIdentidadTipoFinancieroId { get; set; }
        public string DocumentoIdentidadFinanciero { get; set; }
        public string RazonSocial { get; set; }
        public string DireccionFiscal { get; set; }
        public int CuentaContablePorCobrarId { get; set; }
        public int CuentaContablePorPagarId { get; set; }
        public DocumentoIdentidadTipo DocumentoIdentidadTipoFinanciero { get; set; }
        public CuentaContable CuentaContablePorCobrar { get; set; }
        public CuentaContable CuentaContablePorPagar { get; set; }
        public Persona Persona { get; set; }

    }
}
