using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Contabilidad.CuentaContableEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContables.Commands
{
    public sealed record CuentaContableModificarCommand(
        long Id,
        int EmpresaId,
        string Nombre,
        string NombreCorto,
        bool Activo,
        string ES,
        int CuentaContableTipoId,
        int Nivel,
        long? PadreId,
        bool PermiteMovimiento
    ) : IRequest<CuentaContable>, ICommandBase;
}
