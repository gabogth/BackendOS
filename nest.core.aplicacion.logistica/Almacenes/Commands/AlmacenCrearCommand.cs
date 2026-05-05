using MediatR;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Commands;

public record AlmacenCrearCommand(
    string Nombre,
    bool Estado,
    int DistritoId
) : IRequest<Almacen>, IAlmacenGenericCommand;
