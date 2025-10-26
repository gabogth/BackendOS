using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.legal.ContratoTipos.Commands
{
    public sealed record ContratoTipoEliminarCommand(
        byte Id
    ) : IRequest<Unit>, ICommandBase;
}
