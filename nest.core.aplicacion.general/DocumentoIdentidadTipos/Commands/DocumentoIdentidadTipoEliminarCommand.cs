using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Commands
{
    public sealed record DocumentoIdentidadTipoEliminarCommand(
        byte Id
    ) : IRequest<bool>, ICommandBase;
}
