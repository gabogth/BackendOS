using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Contabilidad.CuentaContableEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContables.Commands
{
    public interface ICuentaContableGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        string Nombre { get; }
        string NombreCorto { get; }
        bool Activo { get; }
        string ES { get; }
        int CuentaContableTipoId { get; }
        int Nivel { get; }
        long? PadreId { get; }
        bool PermiteMovimiento { get; }
    }
}
