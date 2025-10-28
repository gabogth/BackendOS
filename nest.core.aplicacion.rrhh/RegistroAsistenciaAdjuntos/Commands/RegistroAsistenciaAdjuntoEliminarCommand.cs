using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Commands;

public record RegistroAsistenciaAdjuntoEliminarCommand(long RegistroAsistenciaId) : IRequest<Unit>, ICommandBase;
