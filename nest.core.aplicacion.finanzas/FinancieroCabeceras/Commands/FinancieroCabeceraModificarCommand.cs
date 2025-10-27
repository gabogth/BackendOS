using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.aplicacion.finanzas.FinancieroCabeceras.Commands
{
    public sealed record FinancieroCabeceraModificarCommand(
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
        string NumeroDocumentoGen
    ) : IRequest<FinancieroCabecera>, IFinancieroCabeceraGenericCommand, ICommandBase;
}
