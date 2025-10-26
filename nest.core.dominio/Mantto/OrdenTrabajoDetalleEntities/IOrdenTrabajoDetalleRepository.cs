using System.Collections.Generic;

namespace nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities
{
    public interface IOrdenTrabajoDetalleRepository
    {
        Task<OrdenTrabajoDetalle> ObtenerPorId(long id);
        Task<List<OrdenTrabajoDetalle>> ObtenerPorIds(List<long> ids);
        Task<List<OrdenTrabajoDetalle>> ObtenerPorCabecera(long ordenTrabajoCabeceraId);
        Task<OrdenTrabajoDetalle> Agregar(OrdenTrabajoDetalle entity);
        Task<OrdenTrabajoDetalle[]> AgregarRange(OrdenTrabajoDetalle[] entities);
        Task<OrdenTrabajoDetalle> Modificar(OrdenTrabajoDetalle entity);
        Task<OrdenTrabajoDetalle[]> ModificarRange(OrdenTrabajoDetalle[] entities);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
        Task<OrdenTrabajoDetalle[]> FusionarRange(OrdenTrabajoDetalle[] originalEntities, OrdenTrabajoDetalle[] entities);
    }
}
