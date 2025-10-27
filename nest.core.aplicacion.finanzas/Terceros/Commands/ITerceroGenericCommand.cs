using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.ClienteEntities;

namespace nest.core.aplicacion.finanzas.Terceros.Commands
{
    public interface ITerceroGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        byte DocumentoIdentidadTipoFinancieroId { get; }
        string DocumentoIdentidadFinanciero { get; }
        string RazonSocial { get; }
        string DireccionFiscal { get; }
        long CuentaContablePorCobrarId { get; }
        long CuentaContablePorPagarId { get; }
    }
}
