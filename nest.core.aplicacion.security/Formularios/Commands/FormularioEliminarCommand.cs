using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.security.Formularios.Commands;

public record FormularioEliminarCommand(int Id) : IRequest<Unit>, ICommandBase;
