using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Commands
{
    public sealed record EstructuraOrganizacionalEliminarCommand(
        int Id
    ) : IRequest<bool>, ICommandBase;
}
