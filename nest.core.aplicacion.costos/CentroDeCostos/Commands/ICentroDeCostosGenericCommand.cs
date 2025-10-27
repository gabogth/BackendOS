using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.aplicacion.costos.CentroDeCostos.Commands
{
    public interface ICentroDeCostosGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        string Nombre { get; }
        string NombreCorto { get; }
        string Codigo { get; }
        bool EsFinal { get; }
        bool Activo { get; }
        int? PadreId { get; }
    }
}
