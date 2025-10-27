using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Commands
{
    public sealed record UsuarioEmpresaSeleccionarCommand(
        string UsuarioId,
        int EmpresaId
    ) : IRequest<Unit>, ICommandBase;
}
