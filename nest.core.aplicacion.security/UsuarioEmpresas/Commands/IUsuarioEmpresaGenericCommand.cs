using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Security.UsuarioEmpresa;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Commands
{
    public interface IUsuarioEmpresaGenericCommand : ICommandBase
    {
        string UsuarioId { get; }
        int EmpresaId { get; }
        bool Actual { get; }
    }
}
