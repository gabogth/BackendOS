using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.security.Modulos.Commands;

public record ModuloEliminarCommand(int Id) : IRequest<Unit>, ICommandBase;
