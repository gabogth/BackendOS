using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Commands;

public record PersonalCargoExternoEliminarCommand(long Id) : IRequest<Unit>, ICommandBase;
