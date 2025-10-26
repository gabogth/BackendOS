using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Commands;

public record HorarioDetalleEliminarCommand(long Id) : IRequest<Unit>, ICommandBase;
