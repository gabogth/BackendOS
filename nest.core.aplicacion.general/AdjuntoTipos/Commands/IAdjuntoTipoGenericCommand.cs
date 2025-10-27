using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.aplicacion.general.AdjuntoTipos.Commands
{
    public interface IAdjuntoTipoGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
        bool Activo { get; }
    }
}
