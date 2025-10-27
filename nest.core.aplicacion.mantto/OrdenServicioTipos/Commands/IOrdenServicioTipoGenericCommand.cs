using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioTipos.Commands
{
    public interface IOrdenServicioTipoGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
        bool Estado { get; }
    }
}
