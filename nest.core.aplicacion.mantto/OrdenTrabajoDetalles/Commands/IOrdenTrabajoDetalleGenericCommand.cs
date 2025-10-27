using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands
{
    public interface IOrdenTrabajoDetalleGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        long OrdenTrabajoCabeceraId { get; }
        long UbicacionTecnicaId { get; }
        int LaborId { get; }
        int HorasProyectadas { get; }
        int HorasEjecutadas { get; }
        string? Descripcion { get; }
        OrdenTrabajoDetalleEstado Estado { get; }
    }
}
