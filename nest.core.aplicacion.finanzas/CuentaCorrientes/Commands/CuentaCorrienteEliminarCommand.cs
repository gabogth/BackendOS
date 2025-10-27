using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.finanzas.CuentaCorrientes.Commands
{
    public sealed record CuentaCorrienteEliminarCommand(
        int Id
    ) : IRequest<bool>, ICommandBase;
}
