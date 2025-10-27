using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Security.UsuarioEmpresa;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Commands
{
    public sealed record UsuarioEmpresaModificarCommand(
        long Id,
        string UsuarioId,
        int EmpresaId,
        bool Actual
    ) : IRequest<UsuarioEmpresa>, ICommandBase;
}
