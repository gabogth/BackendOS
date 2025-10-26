using System.Collections.Generic;

namespace nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities
{
    public interface IOrdenTrabajoDetalleActivoRepository
    {
        Task<OrdenTrabajoDetalleActivo> ObtenerPorId(long id);
        Task<List<OrdenTrabajoDetalleActivo>> ObtenerPorIds(List<long> ids);
        Task<List<OrdenTrabajoDetalleActivo>> ObtenerPorDetalle(long ordenTrabajoDetalleId);
        Task<OrdenTrabajoDetalleActivo> Agregar(OrdenTrabajoDetalleActivo entity);
        Task<OrdenTrabajoDetalleActivo[]> AgregarRange(OrdenTrabajoDetalleActivo[] entities);
        Task<OrdenTrabajoDetalleActivo> Modificar(OrdenTrabajoDetalleActivo entity);
        Task<OrdenTrabajoDetalleActivo[]> ModificarRange(OrdenTrabajoDetalleActivo[] entities);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
        Task<OrdenTrabajoDetalleActivo[]> FusionarRange(OrdenTrabajoDetalleActivo[] originalEntities, OrdenTrabajoDetalleActivo[] entities);
    }
}
