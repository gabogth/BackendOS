using System.Collections.Generic;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.aplicacion.finanzas.Financiero.Commands
{
    public interface IFinancieroGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        int PuntoFinancieroId { get; }
        int Numero { get; }
        short OrigenFinancieroId { get; }
        EstadoFinancieroEnum Estado { get; }
        string Comentarios { get; }
        int TerceroGenId { get; }
        int DocumentoTipoGenId { get; }
        string SerieDocumentoGen { get; }
        string NumeroDocumentoGen { get; }
        List<FinancieroDetalleEntrada> Detalles { get; }
        bool Transaccional { get; }
    }
}
