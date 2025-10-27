using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.aplicacion.finanzas.FinancieroCabeceras.Commands
{
    public interface IFinancieroCabeceraGenericCommand
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
    }
}
