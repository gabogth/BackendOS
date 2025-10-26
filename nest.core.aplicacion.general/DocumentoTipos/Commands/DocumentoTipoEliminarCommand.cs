using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.general.DocumentoTipos.Commands
{
    public sealed record DocumentoTipoEliminarCommand(
        int Id
    ) : IRequest<bool>, ICommandBase;
}
