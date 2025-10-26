using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.finanzas.CuentaCorriente.Commands
{
    public sealed record CuentaCorrienteEliminarCommand(
        int Id
    ) : IRequest<Unit>, ICommandBase;
}
