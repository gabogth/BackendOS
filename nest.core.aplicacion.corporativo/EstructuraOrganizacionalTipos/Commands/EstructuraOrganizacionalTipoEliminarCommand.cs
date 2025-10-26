using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Commands
{
    public sealed record EstructuraOrganizacionalTipoEliminarCommand(
        int Id
    ) : IRequest<bool>, ICommandBase;
}
