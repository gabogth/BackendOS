using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.ClienteEntities;

namespace nest.core.aplicacion.finanzas.Terceros.Commands
{
    public sealed record TerceroCrearCommand(
        int EmpresaId,
        int Id,
        byte DocumentoIdentidadTipoFinancieroId,
        string DocumentoIdentidadFinanciero,
        string RazonSocial,
        string DireccionFiscal,
        long CuentaContablePorCobrarId,
        long CuentaContablePorPagarId
    ) : IRequest<Tercero>, ICommandBase;
}
