using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands;

public record GrupoTrabajoPersonaEliminarCommand(long Id) : IRequest<Unit>, ICommandBase;
