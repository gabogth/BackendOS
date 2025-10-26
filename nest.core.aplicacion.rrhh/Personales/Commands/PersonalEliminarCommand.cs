using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.Personales.Commands;

public record PersonalEliminarCommand(int Id) : IRequest<Unit>, ICommandBase;
