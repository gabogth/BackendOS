using MediatR;

namespace nest.core.aplicacion.logistica.Almacenes.Commands;

public record AlmacenEliminarCommand(int Id) : IRequest;
