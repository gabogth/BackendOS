using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;

namespace nest.core.aplicacion.finanzas.EntidadFinancieras.Commands
{
    public interface IEntidadFinancieraGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        string Nombre { get; }
        string NombreCorto { get; }
        bool Activo { get; }
        bool EsEfectivo { get; }
    }
}
