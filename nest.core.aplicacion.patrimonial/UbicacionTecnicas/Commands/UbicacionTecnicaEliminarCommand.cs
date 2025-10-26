using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicas.Commands
{
    public record UbicacionTecnicaEliminarCommand(
        long Id
    ) : IRequest<bool>, ICommandBase;
}
