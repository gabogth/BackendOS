using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands;

public record HorarioDetalleEventoEliminarCommand(long Id) : IRequest<Unit>, ICommandBase;
