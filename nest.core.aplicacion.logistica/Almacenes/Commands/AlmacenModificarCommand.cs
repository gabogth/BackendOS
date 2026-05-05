using MediatR;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Commands;

public record AlmacenModificarCommand(
    int Id,
    string Nombre,
    string NombreCorto,
    int DistritoId,
    string Direccion,
    decimal latitud,
    decimal lonitud,
    bool Activo
) : IRequest<Almacen>, IAlmacenGenericCommand;
