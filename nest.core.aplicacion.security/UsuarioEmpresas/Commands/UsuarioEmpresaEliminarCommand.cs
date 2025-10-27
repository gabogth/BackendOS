using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Commands
{
    public sealed record UsuarioEmpresaEliminarCommand(
        long Id
    ) : IRequest<Unit>, ICommandBase;
}
