using MediatR;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Commands;

public record AlmacenModificarCommand(
    int Id,
    string Nombre,
    bool Estado,
    int DistritoId
) : IRequest<Almacen>, IAlmacenGenericCommand;
