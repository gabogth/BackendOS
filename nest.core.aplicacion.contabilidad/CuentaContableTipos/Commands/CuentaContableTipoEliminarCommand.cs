using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.contabilidad.CuentaContableTipos.Commands
{
    public sealed record CuentaContableTipoEliminarCommand(
        int Id
    ) : IRequest<Unit>, ICommandBase;
}
