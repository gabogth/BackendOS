using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.logistica.Almacenes.Commands;

public interface IAlmacenGenericCommand : ICommandBase
{
    int EmpresaId { get; }
    string Nombre { get; }
    string NombreCorto { get; }
    int DistritoId { get; }
    string Direccion { get; }
    decimal Latitud { get; }
    decimal Longitud { get; }
    bool Activo { get; }
}
