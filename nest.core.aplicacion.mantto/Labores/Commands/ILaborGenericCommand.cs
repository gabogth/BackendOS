using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.LaborEntities;

namespace nest.core.aplicacion.mantto.Labores.Commands
{
    public interface ILaborGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
        bool Activo { get; }
    }
}
