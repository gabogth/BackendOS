using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands;

public record RegistroAsistenciaPoliticaEliminarCommand(long Id) : IRequest<Unit>, ICommandBase;
