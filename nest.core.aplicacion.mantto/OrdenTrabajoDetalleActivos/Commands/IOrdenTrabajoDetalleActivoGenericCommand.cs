using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands
{
    public interface IOrdenTrabajoDetalleActivoGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        long OrdenTrabajoDetalleId { get; }
        long ActivoId { get; }
    }
}
