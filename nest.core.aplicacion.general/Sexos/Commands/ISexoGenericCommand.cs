using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.aplicacion.general.Sexos.Commands
{
    public interface ISexoGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
    }
}
