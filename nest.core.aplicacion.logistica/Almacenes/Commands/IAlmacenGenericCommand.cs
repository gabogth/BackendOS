using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.logistica.Almacenes.Commands;

public interface IAlmacenGenericCommand : ICommandBase
{
    string Nombre { get; }
    string NombreCorto { get; }
    int DistritoId { get; }
    string Direccion { get; }
    decimal latitud { get; }
    decimal lonitud { get; }
    bool Activo { get; }
}
