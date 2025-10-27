using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.aplicacion.finanzas.Financiero.Commands
{
    public sealed record FinancieroModificarCommand(
        long Id,
        int EmpresaId,
        int PuntoFinancieroId,
        int Numero,
        short OrigenFinancieroId,
        EstadoFinancieroEnum Estado,
        string Comentarios,
        int TerceroGenId,
        int DocumentoTipoGenId,
        string SerieDocumentoGen,
        string NumeroDocumentoGen,
        List<FinancieroDetalleEntrada> Detalles,
        bool Transaccional = true
    ) : IRequest<FinancieroCabecera>, IFinancieroGenericCommand;
}
