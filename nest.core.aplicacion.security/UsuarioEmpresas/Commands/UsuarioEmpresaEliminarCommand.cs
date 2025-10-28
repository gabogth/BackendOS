using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Commands
{
    public sealed record UsuarioEmpresaEliminarCommand(
        int Id
    ) : IRequest<Unit>, ICommandBase;
}
