using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Commands;

public record PersonalEstadoEliminarCommand(byte Id) : IRequest<Unit>, ICommandBase;
