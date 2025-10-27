using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.general.Distritos.Commands
{
    public interface IDistritoGenericCommand : ICommandBase
    {
        string Nombre { get; }
        int ProvinciaId { get; }
    }
}
