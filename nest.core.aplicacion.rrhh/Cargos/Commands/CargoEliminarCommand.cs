using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.Cargos.Commands;

public record CargoEliminarCommand(int Id) : IRequest<Unit>, ICommandBase;
