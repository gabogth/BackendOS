using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;

namespace nest.core.aplicacion.mantto.MantenimientoTipos.Commands
{
    public interface IMantenimientoTipoGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
        bool Activo { get; }
    }
}
