using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.logistica.Almacenes.Commands;

public interface IAlmacenGenericCommand : ICommandBase
{
    string Nombre { get; }
    bool Estado { get; }
    int DistritoId { get; }
}
