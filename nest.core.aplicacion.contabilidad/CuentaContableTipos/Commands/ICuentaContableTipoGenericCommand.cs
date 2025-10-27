using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContableTipos.Commands
{
    public interface ICuentaContableTipoGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
        bool Activo { get; }
    }
}
